using UnityEngine;

public class PlayableCar : MonoBehaviour, IObstacleInteractable, IBusterInteractable
{
    [field: SerializeField] public Inputs Inputs { get; private set; }
    [field: SerializeField] public Rigidbody2D Rigidbody { get; private set; }
    [field: SerializeField] public PlayableCarData Data { get; private set; }
    public IdleState IdleState { get; private set; }
    public MoveState MoveState { get; private set; }
    public NoneAbilityState NoneAbilityState { get; private set; }
    public SpeedBoostAbilityState SpeedBoost { get; private set; }
    public MagnetAbilityState MagnetAbility { get; private set; }

    private StateMachine _stateMachine;
    private StateMachine _abilityStateMachine;
    private Health _health;

    private float _friction = 0;

    public float Friction => _friction;

    public void Initialize(Health health)
    {
        _health = health;
        _stateMachine = new StateMachine(this);
        _abilityStateMachine = new StateMachine(this);

        IdleState = new IdleState(_stateMachine);
        MoveState = new MoveState(_stateMachine);
        SpeedBoost = new SpeedBoostAbilityState(_stateMachine, 15f, 30f);
        MagnetAbility = new MagnetAbilityState(_abilityStateMachine, 15f);

        NoneAbilityState = new NoneAbilityState(_abilityStateMachine, 15f);
    }

    private void Start()
    {
        _stateMachine.Initialize(IdleState);
        _abilityStateMachine.Initialize(NoneAbilityState);
    }

    private void Update()
    {
        _stateMachine.UpdateState();
    }

    private void FixedUpdate()
    {
        _stateMachine.UpdatePhysics();
    }

    public void HandleEffect(Interaction interaction)
    {
        _health.TakeDamage(interaction.Damage);
        _friction = interaction.Friction;
    }

    public void StopEffect()
    {
        _friction = 0;
    }

    public void HandleBusterEffect(BoosterType type)
    {
        switch (type) 
        {
            case BoosterType.Speed:
                _stateMachine.SetState(SpeedBoost);
                break;
            case BoosterType.Magnet:
                _abilityStateMachine.SetState(MagnetAbility);
                break;
            case BoosterType.Shield:
                break;
        }
        
    }
}

using UnityEngine;

public class PlayableCar : MonoBehaviour, IObstacleInteractable
{
    [field: SerializeField] public Inputs Inputs { get; private set; }
    [field: SerializeField] public Rigidbody2D Rigidbody { get; private set; }
    [field: SerializeField] public PlayableCarData Data { get; private set; }
    public IdleState IdleState { get; private set; }
    public MoveState MoveState { get; private set; }

    private StateMachine _stateMachine;
    private Health _health;

    private float _friction = 0;

    public float Friction => _friction;

    public void Initialize(Health health)
    {
        _health = health;
        _stateMachine = new StateMachine(this);

        IdleState = new IdleState(_stateMachine);
        MoveState = new MoveState(_stateMachine);
    }

    private void Start()
    {
        _stateMachine.Initialize(IdleState);
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
}

using UnityEngine;

public abstract class State
{
    protected PlayableCar player { get; private set; }

    private StateMachine _stateMachine;
    protected StateMachine Machine => _stateMachine;
    public State(StateMachine stateMachine)
    {
        _stateMachine = stateMachine;
        player = stateMachine.Player;
    }

    public virtual void Enter() 
    {
        UnityEngine.Debug.Log(GetType());
    }
    public virtual void Update() { }
    public virtual void PhysicsUpdate() { }
    public virtual void Exit() { }
}

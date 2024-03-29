public class StateMachine
{
    private State _currentState;
    private PlayableCar _player;

    public PlayableCar Player => _player;

    public StateMachine(PlayableCar listener) 
    {
        _player = listener;
    }

    public void Initialize(State initialState)
    {
        _currentState = initialState;
        _currentState.Enter();
    }

    public void SetState(State newState)
    {
        _currentState?.Exit();
        _currentState = newState;
        _currentState.Enter();
    }

    public void UpdateState()
    {
        _currentState?.Update();
    }

    public void UpdatePhysics()
    {
        _currentState?.PhysicsUpdate();
    }
}

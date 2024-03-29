using UnityEngine;

public abstract class AbilityState : State
{
    private float _timeToFinish;
    private float _startTime;

    private bool _isFinished;

    protected bool IsFinished => _isFinished;

    public AbilityState(StateMachine stateMachine, float timeToFinish) : base(stateMachine)
    {
        _timeToFinish = timeToFinish;
    }

    public override void Enter()
    {
        base.Enter();

        _startTime = Time.time;
    }

    public override void Update()
    {
        if (Time.time >= _startTime + _timeToFinish)
        {
            _isFinished = true;
        }
    }
}

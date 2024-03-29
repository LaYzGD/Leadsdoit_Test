using UnityEngine;

public class IdleState : State
{
    private Inputs _inputs;
    public IdleState(StateMachine stateMachine) : base(stateMachine)
    {
        _inputs = player.Inputs;
    }

    public override void Enter()
    {
        player.Rigidbody.velocity = Vector2.zero;
    }

    public override void Update()
    {
        if (_inputs.IsAcceleration)
        {
            Machine.SetState(player.MoveState);
        }
    }
}

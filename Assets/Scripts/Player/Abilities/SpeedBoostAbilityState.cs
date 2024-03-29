using System;
using UnityEngine;

public class SpeedBoostAbilityState : AbilityState
{
    private float _movementSpeed;
    private Rigidbody2D _rigidbody;
    public SpeedBoostAbilityState(StateMachine stateMachine, float timeToFinish, float movementSpeed) : base(stateMachine, timeToFinish)
    {
        _movementSpeed = movementSpeed;
        _rigidbody = player.Rigidbody;
    }

    public override void Update()
    {
        base.Update();

        if (IsFinished)
        {
            Machine.SetState(player.MoveState);
        }
    }

    public override void PhysicsUpdate()
    {
        _rigidbody.velocity = new Vector2(0, _movementSpeed);
    }
}

using UnityEngine;

public class MoveState : State
{
    private Inputs _inputs;
    private Rigidbody2D _rigidbody;
    private PlayableCarData _data;

    private float _verticalMovementSpeed;
    private float _horizontalMovementSpeed;

    public MoveState(StateMachine stateMachine) : base(stateMachine)
    {
        _inputs = player.Inputs;
        _rigidbody = player.Rigidbody;
        _data = player.Data;
    }

    public override void Enter()
    {
        base.Enter();

        _verticalMovementSpeed = _data.BaseMovementSpeed.y;
        _horizontalMovementSpeed = _data.BaseMovementSpeed.x;
    }

    public override void PhysicsUpdate()
    {
        CheckSpeed();

        _rigidbody.velocity = new Vector2(_inputs.MovementAxis * _horizontalMovementSpeed, _verticalMovementSpeed);

        if (Mathf.Floor(_verticalMovementSpeed) == 0f)
        {
            Machine.SetState(player.IdleState);
        }
    }

    private void CheckSpeed()
    {
        if (_verticalMovementSpeed > _data.MaxSpeed)
        {
            _verticalMovementSpeed = _data.MaxSpeed;
        }

        if (_verticalMovementSpeed < _data.MinSpeed)
        {
            _verticalMovementSpeed = _data.MinSpeed;
        }

        if (_inputs.IsAcceleration)
        {
            _verticalMovementSpeed += ((_data.Acceleration - player.Friction) / _data.AccelerationTime) * Time.fixedDeltaTime;

            return;
        }

        if (_inputs.IsDeceleration)
        {
            _verticalMovementSpeed -= ((_data.Brake + player.Friction) / _data.BrakeTime) * Time.fixedDeltaTime;

            return;
        }

        _verticalMovementSpeed -= ((_data.Deceleration + player.Friction)/ _data.DecelerationTime) * Time.fixedDeltaTime;
    }
}

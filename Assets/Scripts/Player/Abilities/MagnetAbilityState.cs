using System;

public class MagnetAbilityState : AbilityState
{
    public MagnetAbilityState(StateMachine stateMachine, float timeToFinish) : base(stateMachine, timeToFinish)
    {
    }

    public override void Update()
    {
        base.Update();

        if (IsFinished)
        {
            Machine.SetState(player.NoneAbilityState);
        }
    }
}

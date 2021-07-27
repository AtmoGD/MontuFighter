using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : State
{
    public override void Enter(StateMachine _machine, string _animationParameter = "")
    {
        base.Enter(_machine);
    }

    public override void UpdateFrame()
    {
        base.UpdateFrame();

        if (Machine.Inputs.Movement.magnitude >= 0.1f)
        {
            Machine.SetState(new PlayerMovementState());
            return;
        }

        if (Machine.Inputs.Jump)
        {
            Machine.SetState(new PlayerJumpState());
            return;
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}

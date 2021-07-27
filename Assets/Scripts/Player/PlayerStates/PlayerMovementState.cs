using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementState : State
{
    private PlayerController player;

    public override void Enter(StateMachine _machine, string _animationParameter = "Move")
    {
        base.Enter(_machine, "Move");
        player = Machine as PlayerController;
    }

    public override void UpdateFrame()
    {
        base.UpdateFrame();

        if (Machine.Inputs.Movement.magnitude <= 0.1f)
        {
            Machine.SetState(new PlayerIdleState());
            return;
        }

        if (Machine.Inputs.Jump)
        {
            Machine.SetState(new PlayerJumpState());
            return;
        }

    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        player.Move();
    }

    public override void Exit()
    {
        base.Exit();
    }
}

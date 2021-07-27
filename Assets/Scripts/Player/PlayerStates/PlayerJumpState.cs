using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : State
{
    private PlayerController player;
    public override void Enter(StateMachine _machine, string _animationParameter = "Jump")
    {
        base.Enter(_machine, "Jump");

        player = Machine as PlayerController;
        player.Jump();
    }

    public override void UpdateFrame()
    {
        base.UpdateFrame();

        if (player.Inputs.Movement.magnitude >= 0.1f)
            player.Move();

        if (player.IsGrounded() && player.rb.velocity.y <= 0f)
        {
            player.SetState(new PlayerIdleState());
            return;
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}

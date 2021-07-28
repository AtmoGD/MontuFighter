using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerActiveState
{
    public override void Enter(StateMachine _machine, string _animationParameter = "Jump")
    {
        base.Enter(_machine, "Jump");

        Jump();
    }

    public override void UpdateFrame()
    {
        base.UpdateFrame();

        if (Player.Inputs.Movement.magnitude >= 0.1f)
            JumpMove();

        if (Player.IsGrounded && Player.rb.velocity.y <= 0f)
        {
            Player.SetState(new PlayerIdleState());
            return;
        }
    }

    public void JumpMove()
    {
        Vector3 lookAtPos = Player.transform.position;
        lookAtPos.x += Player.Inputs.Movement.x;
        lookAtPos.z += Player.Inputs.Movement.y;
        Player.transform.LookAt(lookAtPos);

        Vector3 desVel = Player.transform.forward * Player.GetData().jumpMovementSpeed;
        Vector3 newVel = Player.rb.velocity;
        newVel.x = desVel.x;
        newVel.z = desVel.z;

        Player.rb.velocity = newVel;
    }

    protected void Jump()
    {
        Vector3 velocity = Player.rb.velocity;
        velocity.y = Player.GetData().jumpForce;
        Player.rb.velocity = velocity;
    }

    public override void Exit()
    {
        base.Exit();
    }
}

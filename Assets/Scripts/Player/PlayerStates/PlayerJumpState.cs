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
        Jump();
    }

    public override void UpdateFrame()
    {
        base.UpdateFrame();

        if (player.Inputs.Movement.magnitude >= 0.1f)
            Move();

        if (player.IsGrounded() && player.rb.velocity.y <= 0f)
        {
            player.SetState(new PlayerIdleState());
            return;
        }
    }
    public void Move()
    {
        Vector3 lookAtPos = player.transform.position;
        lookAtPos.x += player.Inputs.Movement.x;
        lookAtPos.z += player.Inputs.Movement.y;
        player.transform.LookAt(lookAtPos);

        Vector3 newPos = player.transform.position + player.transform.forward * player.data.jumpMovementSpeed;
        player.rb.MovePosition(newPos);
    }

    public void Jump()
    {
        Vector3 velocity = player.rb.velocity;
        velocity.y = player.data.jumpForce;
        player.rb.velocity = velocity;
    }

    public override void Exit()
    {
        base.Exit();
    }
}

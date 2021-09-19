using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : ActiveState
{
    public override void Enter(StateMachine _machine, string _animationParameter = "Jump")
    {
        base.Enter(_machine, "Jump");
        
        Jump();
    }

    public override void UpdateFrame()
    {
        base.UpdateFrame();

        if (Character.Inputs.Movement.magnitude >= 0.1f)
            JumpMove();

        if (Character.IsGrounded && Character.rb.velocity.y <= 0f)
        {
            Character.SetState(new IdleState());
            return;
        }

        ApplyGravity();
    }

    public void JumpMove()
    {
        Vector3 lookAtPos = Character.rb.transform.position;
        lookAtPos.x += Character.Inputs.Movement.x;
        lookAtPos.z += Character.Inputs.Movement.y;
        Character.rb.transform.LookAt(lookAtPos);

        Vector3 desVel = Character.rb.transform.forward * Character.GetData().jumpMovementSpeed;
        Vector3 newVel = Character.rb.velocity;
        newVel.x = desVel.x;
        newVel.z = desVel.z;

        Character.rb.velocity = newVel;
    }

    protected void Jump()
    {
        Vector3 velocity = Character.rb.velocity;
        velocity.y = Character.GetData().jumpForce;
        Character.rb.velocity = velocity;
    }

    protected void ApplyGravity()
    {
        Vector3 velocity = Character.rb.velocity;
        velocity.y -= Character.GetData().gravity;
        Character.rb.velocity = velocity;
    }
}

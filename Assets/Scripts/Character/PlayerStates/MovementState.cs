using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementState : ActiveState
{

    public override void Enter(StateMachine _machine, string _animationParameter = "Move")
    {
        base.Enter(_machine, "Move");
    }

    public override void UpdateFrame()
    {
        base.UpdateFrame();

        if (Character.Inputs.Movement.magnitude <= 0.1f)
        {
            Character.SetState(new IdleState());
            return;
        }
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();

        Move();
    }

    public void Move()
    {
        Vector3 lookAtPos = Character.transform.position;
        lookAtPos.x += Character.Inputs.Movement.x;
        lookAtPos.z += Character.Inputs.Movement.y;
        Character.transform.LookAt(lookAtPos);

        Vector3 desVel = Character.transform.forward * Character.GetData().movementSpeed;
        Vector3 newVel = Character.rb.velocity;
        newVel.x = desVel.x;
        newVel.z = desVel.z;

        Character.rb.velocity = Vector3.Lerp(Character.rb.velocity,  newVel, Character.GetData().movementVelocityChange);

        Character.State.SetAnimator(Character.GetData().animMoveSpeedName, Character.rb.velocity.magnitude * Character.GetData().speedAnimationMultiplier);

        // Player.animator.SetFloat(Player.GetData().animMoveSpeedName, Player.rb.velocity.magnitude * Player.GetData().speedAnimationMultiplier);
    }
}

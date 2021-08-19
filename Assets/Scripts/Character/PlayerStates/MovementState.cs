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

        if (Player.Inputs.Movement.magnitude <= 0.1f)
        {
            Player.SetState(new IdleState());
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
        Vector3 lookAtPos = Player.transform.position;
        lookAtPos.x += Player.Inputs.Movement.x;
        lookAtPos.z += Player.Inputs.Movement.y;
        Player.transform.LookAt(lookAtPos);

        Vector3 desVel = Player.transform.forward * Player.GetData().movementSpeed;
        Vector3 newVel = Player.rb.velocity;
        newVel.x = desVel.x;
        newVel.z = desVel.z;

        Player.rb.velocity = Vector3.Lerp(Player.rb.velocity,  newVel, Player.GetData().movementVelocityChange);

        Player.State.SetAnimator(Player.GetData().animMoveSpeedName, Player.rb.velocity.magnitude * Player.GetData().speedAnimationMultiplier);

        // Player.animator.SetFloat(Player.GetData().animMoveSpeedName, Player.rb.velocity.magnitude * Player.GetData().speedAnimationMultiplier);
    }
}

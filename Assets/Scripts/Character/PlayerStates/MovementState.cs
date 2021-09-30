using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementState : ActiveState
{
    float turnSmoothTime;
    // Vector3 desiredMovement = Vector3.zero;
    // Quaternion desiredRotation = Quaternion.identity;

    float turnSmoothVelocity;

    float moveSpeed;
    // bool isJumping = false;
    // float jumpStartTime;


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
        Vector3 moveDir = Vector3.zero;
        moveDir.x += Character.Inputs.Movement.x;
        moveDir.z += Character.Inputs.Movement.y;
        // Character.rb.transform.LookAt(moveDir);

        float targetAngle = Mathf.Atan2(moveDir.x, moveDir.z) * Mathf.Rad2Deg + Character.GetCamTransform().transform.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(Character.transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

        Character.transform.rotation = Quaternion.Euler(0f, angle, 0f);

        moveSpeed = Mathf.Lerp(moveSpeed, Character.GetData().movementSpeed, Character.GetData().movementVelocityChange * Time.deltaTime);

        Vector3 targetPos = Character.transform.position + Character.transform.forward * moveSpeed;
        targetPos = Vector3.Lerp(Character.transform.position, targetPos, Character.GetData().movementVelocityChange * Time.deltaTime);
        // Character.rb.MovePosition(targetPos);
        Character.rb.velocity = targetPos - Character.transform.position;
        // }


        // Vector3 desVel = Character.rb.transform.forward * Character.GetData().movementSpeed;
        // Vector3 newVel = Character.rb.velocity;
        // newVel.x = desVel.x;
        // newVel.z = desVel.z;

        // Character.rb.velocity = Vector3.Lerp(Character.rb.velocity, newVel, Character.GetData().movementVelocityChange);

        // Character.State.SetAnimator(Character.GetData().animMoveSpeedName, Character.rb.velocity.magnitude * Character.GetData().speedAnimationMultiplier);
        // desiredMovement.x += Character.Inputs.Movement.x;
        // desiredMovement.z += Character.Inputs.Movement.y;
        // // Character.rb.transform.LookAt(lookAtPos);

        // // Vector3 desVel = Character.rb.transform.forward * Character.GetData().movementSpeed;
        // // Vector3 newVel = Character.rb.velocity;
        // // newVel.x = desVel.x;
        // // newVel.z = desVel.z;

        // // Character.rb.velocity = Vector3.Lerp(Character.rb.velocity,  newVel, Character.GetData().movementVelocityChange);
        // float targetAngle = Mathf.Atan2(desiredMovement.x, desiredMovement.z) * Mathf.Rad2Deg + Character.transform.eulerAngles.y;
        // float angle = Mathf.SmoothDampAngle(Character.transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

        // desiredRotation = Quaternion.Euler(0, angle, 0);

        // desiredMovement = Quaternion.Euler(0, angle, 0) * Vector3.forward * Character.GetData().movementSpeed * Time.fixedDeltaTime;

        // Character.transform.rotation = desiredRotation;

        // Character.rb.velocity = desiredMovement;

        // Character.State.SetAnimator(Character.GetData().animMoveSpeedName, Character.rb.velocity.magnitude * Character.GetData().speedAnimationMultiplier);

        // // Player.animator.SetFloat(Player.GetData().animMoveSpeedName, Player.rb.velocity.magnitude * Player.GetData().speedAnimationMultiplier);
    }
}

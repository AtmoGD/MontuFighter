using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : ActiveState
{
    float turnSmoothTime;
    // Vector3 desiredMovement = Vector3.zero;
    // Quaternion desiredRotation = Quaternion.identity;

    float turnSmoothVelocity;

    float moveSpeed;
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

        // ApplyGravity();

    }

    public void JumpMove()
    {
        Vector3 moveDir = Vector3.zero;
        moveDir.x += Character.Inputs.Movement.x;
        
        moveDir.z += Character.Inputs.Movement.y;
        // Character.rb.transform.LookAt(moveDir);

        float targetAngle = Mathf.Atan2(moveDir.x, moveDir.z) * Mathf.Rad2Deg + Character.GetCamTransform().transform.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(Character.transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

        Character.transform.rotation = Quaternion.Euler(0f, angle, 0f);

        moveSpeed = Mathf.Lerp(moveSpeed, Character.GetData().jumpMovementSpeed, Character.GetData().jumpMovementVelocityChange * Time.deltaTime);

        Vector3 targetPos = Character.transform.position + Character.transform.forward * moveSpeed;
        targetPos = Vector3.Lerp(Character.transform.position, targetPos, Character.GetData().movementVelocityChange * Time.deltaTime);
        targetPos += Vector3.up * Character.GetData().gravity * Time.deltaTime;
        moveDir.y = Character.rb.velocity.y;
        // Character.rb.MovePosition(targetPos);
        // Character.rb.velocity = moveDir;
        Character.rb.AddForce(moveDir * Character.GetData().jumpMovementSpeed * Time.deltaTime, ForceMode.VelocityChange);
        // Vector3 moveDir = Vector3.zero;
        // moveDir.x += Character.Inputs.Movement.x;
        // moveDir.z += Character.Inputs.Movement.y;
        // // Character.rb.transform.LookAt(moveDir);

        // // if (moveDir.magnitude > 0.1f)
        // // {
        // float targetAngle = Mathf.Atan2(moveDir.x, moveDir.z) * Mathf.Rad2Deg + Character.GetCamTransform().transform.eulerAngles.y;
        // float angle = Mathf.SmoothDampAngle(Character.transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

        // Character.transform.rotation = Quaternion.Euler(0f, angle, 0f);

        // moveSpeed = Mathf.Lerp(moveSpeed, Character.GetData().jumpMovementSpeed, Character.GetData().jumpMovementVelocityChange * Time.deltaTime);
        // Vector3 targetPos = Character.transform.position + Character.transform.forward * moveSpeed;
        // Character.rb.velocity = (Character.rb.velocity + (targetPos - Character.rb.position)).Scale(Character.rb.velocity);
        // // targetPos = Vector3.Lerp(Character.transform.position, targetPos, Character.GetData().movementVelocityChange * Time.deltaTime);
        // // Character.rb.MovePosition(targetPos);
        // // Character.rb.velocity = (targetPos - Character.transform.position) * Character.GetData().movementVelocityChange;
        // // Character.rb.velocity = moveDir * moveSpeed;
        // // Vector3 lookAtPos = Character.rb.transform.position;
        // // lookAtPos.x += Character.Inputs.Movement.x;
        // // lookAtPos.z += Character.Inputs.Movement.y;
        // // Character.rb.transform.LookAt(lookAtPos);

        // // Vector3 desVel = Character.rb.transform.forward * Character.GetData().jumpMovementSpeed;
        // // Vector3 newVel = Character.rb.velocity;
        // // newVel.x = desVel.x;
        // // newVel.z = desVel.z;

        // // Character.rb.velocity = newVel;
    }

    protected void Jump()
    {
        Vector3 dir = Vector3.up * Character.GetData().jumpForce;
        Character.rb.AddForce(dir, ForceMode.Impulse);
        // Vector3 velocity = Character.rb.velocity;
        // velocity.y = Character.GetData().jumpForce;
        // Character.rb.velocity = velocity;
    }

    protected void ApplyGravity()
    {
        Vector3 velocity = Character.rb.velocity;
        velocity.y += Character.GetData().gravity;
        Character.rb.velocity = velocity;
    }
}

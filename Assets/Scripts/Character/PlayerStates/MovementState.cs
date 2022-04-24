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

        Character.Move(Character.Inputs.Movement);

        if (Character.Inputs.Look.magnitude >= 0.1f)
            Character.Rotate(Character.Inputs.Look);
        else
            Character.Rotate(Character.Inputs.Movement);
    }

    // public void Rotate(Vector2 _input) {
    //     Vector3 LookAt = Character.animator.transform.position;
    //     LookAt += new Vector3(_input.x, 0, _input.y);
    //     Character.animator.transform.LookAt(LookAt);
    // }

    // public void Move(Vector2 _input)
    // {
    //     Vector3 moveDir = Vector3.zero;
    //     moveDir.x += _input.x;
    //     moveDir.z += _input.y;

    //     moveSpeed = Mathf.Lerp(moveSpeed, Character.GetData().movementSpeed, Character.GetData().movementVelocityChange * Time.deltaTime);

    //     Character.rb.AddForce(moveDir * moveSpeed, ForceMode.VelocityChange);

    //     Character.animator.SetFloat("MovementSpeed", moveSpeed);

    //     Rotate(_input);
    // }
}

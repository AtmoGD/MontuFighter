using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : ActiveState
{
    public override void Enter(StateMachine _machine, string _animationParameter = "")
    {
        base.Enter(_machine, _animationParameter);

        Character.rb.velocity = Vector3.zero;
    }

    public override void UpdateFrame()
    {
        base.UpdateFrame();

        if (Character.Inputs.Movement.magnitude >= 0.1f)
        {
            Character.SetState(new MovementState());
            return;
        }
    }
}

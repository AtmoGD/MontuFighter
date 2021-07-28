using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerActiveState
{
    public override void Enter(StateMachine _machine, string _animationParameter = "")
    {
        base.Enter(_machine, _animationParameter);

        Player.rb.velocity = Vector3.zero;
    }

    public override void UpdateFrame()
    {
        base.UpdateFrame();

        if (Player.Inputs.Movement.magnitude >= 0.1f)
        {
            Player.SetState(new PlayerMovementState());
            return;
        }
    }
}

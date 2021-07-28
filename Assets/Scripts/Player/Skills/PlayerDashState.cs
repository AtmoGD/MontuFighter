using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerState
{
    float distanceLeft = 0f;
    public override void Enter(StateMachine _machine, string _animationParameter = "Dash")
    {
        base.Enter(_machine, "Dash");

        distanceLeft = Player.GetData().dashDistance;
    }

    public override void UpdateFrame()
    {
        base.UpdateFrame();

        Dash();

        if (distanceLeft <= 0f)
        {
            Player.SetState(new PlayerIdleState());
        }
    }

    public void Dash()
    {
        Vector3 lookAtPos = Player.transform.position;
        lookAtPos.x += Player.Inputs.Movement.x;
        lookAtPos.z += Player.Inputs.Movement.y;
        Player.transform.LookAt(lookAtPos);

        Vector3 newPos = Player.transform.position + Player.transform.forward * Player.GetData().dashMovementSpeed;
        distanceLeft -= Vector3.Distance(Player.transform.position, newPos);

        Player.rb.MovePosition(newPos);
    }

    public override void Exit()
    {
        base.Exit();
    }
}

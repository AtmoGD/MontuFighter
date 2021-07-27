using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : State
{
    PlayerController player;
    float distanceLeft = 0f;
    public override void Enter(StateMachine _machine, string _animationParameter = "Dash")
    {
        base.Enter(_machine, "Dash");
        player = Machine as PlayerController;

        distanceLeft = player.data.dashDistance;
    }

    public override void UpdateFrame()
    {
        base.UpdateFrame();

        Dash();

        if (distanceLeft <= 0f)
        {
            player.SetState(new PlayerIdleState());
        }
    }

    public void Dash()
    {
        Vector3 lookAtPos = player.transform.position;
        lookAtPos.x += player.Inputs.Movement.x;
        lookAtPos.z += player.Inputs.Movement.y;
        player.transform.LookAt(lookAtPos);

        Vector3 newPos = player.transform.position + player.transform.forward * player.data.dashMovementSpeed;
        distanceLeft -= Vector3.Distance(player.transform.position, newPos);

        player.rb.MovePosition(newPos);
    }

    public override void Exit()
    {
        base.Exit();
    }
}

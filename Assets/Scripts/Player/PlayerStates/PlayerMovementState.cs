using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementState : State
{
    private PlayerController player;

    public override void Enter(StateMachine _machine, string _animationParameter = "Move")
    {
        base.Enter(_machine, "Move");
        player = Machine as PlayerController;
    }

    public override void UpdateFrame()
    {
        base.UpdateFrame();

        if (Machine.Inputs.Movement.magnitude <= 0.1f)
        {
            Machine.SetState(new PlayerIdleState());
            return;
        }

        if (Machine.Inputs.Jump)
        {
            Machine.SetState(new PlayerJumpState());
            return;
        }

        if (Machine.Inputs.FirstSkill)
        {
            Machine.SetState(player.GetNewSkillState(true));
            return;
        }

        if (Machine.Inputs.SecondSkill)
        {
            Machine.SetState(player.GetNewSkillState(false));
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
        Vector3 lookAtPos = player.transform.position;
        lookAtPos.x += player.Inputs.Movement.x;
        lookAtPos.z += player.Inputs.Movement.y;
        player.transform.LookAt(lookAtPos);

        Vector3 newPos = player.transform.position + player.transform.forward * player.data.movementSpeed;
        player.rb.MovePosition(newPos);
    }

    public override void Exit()
    {
        base.Exit();
    }
}

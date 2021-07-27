using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : State
{
    PlayerController player;
    public override void Enter(StateMachine _machine, string _animationParameter = "")
    {
        base.Enter(_machine);
        player = Machine as PlayerController;
    }

    public override void UpdateFrame()
    {
        base.UpdateFrame();

        if (Machine.Inputs.Movement.magnitude >= 0.1f)
        {
            Machine.SetState(new PlayerMovementState());
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

    public override void Exit()
    {
        base.Exit();
    }
}

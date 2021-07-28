public class PlayerActiveState : PlayerState
{
    public override void Enter(StateMachine _machine, string _animationParameter = "")
    {
        base.Enter(_machine, _animationParameter);
    }

    public override void UpdateFrame()
    {
        base.UpdateFrame();

        if (Player.Inputs.Jump && Player.IsGrounded)
        {
            Machine.SetState(new PlayerJumpState());
            return;
        }

        if (Player.Inputs.AttackSkill)
        {
            Player.SetState(Player.GetNewSkillState(true));
            return;
        }

        if (Player.Inputs.SupportSkill)
        {
            Player.SetState(Player.GetNewSkillState(false));
            return;
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}

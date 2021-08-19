public class ActiveState : CharacterState
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
            Machine.SetState(new JumpState());
            return;
        }

        if (Player.Inputs.AttackSkill)
        {
            Player.SetState(StateFactory.Create(Player.GetAttackSkill()));
            return;
        }

        if (Player.Inputs.SupportSkill)
        {
            Player.SetState(StateFactory.Create(Player.GetSupportSkill()));
            return;
        }
    }
}

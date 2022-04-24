public class    ActiveState : CharacterState
{
    public override void Enter(StateMachine _machine, string _animationParameter = "")
    {
        base.Enter(_machine, _animationParameter);
    }

    public override void UpdateFrame()
    {
        base.UpdateFrame();

        if (Character.Inputs.Jump && Character.IsGrounded)
        {
            Machine.SetState(new JumpState());
            return;
        }

        if (Character.Inputs.AttackSkill)
        {
            Character.SetState(StateFactory.Create(Character.GetAttackSkill()));
            return;
        }

        if (Character.Inputs.SupportSkill)
        {
            Character.SetState(StateFactory.Create(Character.GetSupportSkill()));
            return;
        }

        if (Character.Inputs.SideSkill)
        {
            Character.SetState(StateFactory.Create(Character.GetSideSkill()));
            return;
        }
    }
}

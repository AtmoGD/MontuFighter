using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : State
{
    public PlayerController Player { get; private set; }
    public override void Enter(StateMachine _machine, string _animationParameter = "")
    {
        base.Enter(_machine, _animationParameter);
        Player = Machine as PlayerController;
    }

    public override void UpdateFrame()
    {
        base.UpdateFrame();
    }

    public override void Exit()
    {
        base.Exit();
    }
}

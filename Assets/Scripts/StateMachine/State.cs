using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    public virtual StateMachine Machine { get; set; }
    protected string animationParameter = "Move";

    public virtual void Enter(StateMachine _machine, string _animationParameter = "")
    {
        Machine = _machine;
        animationParameter = _animationParameter;

        if (animationParameter != "")
            SetAnimator(animationParameter, true);
    }
    public virtual void UpdateFrame() { }
    public virtual void UpdatePhysics() { }
    public virtual void Exit()
    {
        if (animationParameter != "")
            SetAnimator(animationParameter, false);
    }
    public virtual void SetAnimator(string _animationParameter, bool _value)
    {
        Machine.animator.SetBool(_animationParameter, _value);
    }
}

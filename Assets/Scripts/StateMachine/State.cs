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

    public virtual void OnTriggerEnter(Collider _collider) { }
    public virtual void OnTriggerStay(Collider _collider) { }
    public virtual void OnTriggerExit(Collider _collider) { }

    public virtual void OnCollisionEnter(Collision _collision) { }
    public virtual void OnCollisionStay(Collision _collision) { }
    public virtual void OnCollisionExit(Collision _collision) { }
}

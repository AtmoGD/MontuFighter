using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterState : State
{
    public CharacterController Character { get; private set; }
    public override void Enter(StateMachine _machine, string _animationParameter = "")
    {
        base.Enter(_machine, _animationParameter);
        Character = Machine as CharacterController;
    }

    public override void UpdateFrame() {
        
    }

    public virtual void TakeDamage(Damage _damage)
    {
        if (Character.HealthLeft <= 0) return;

        Character.SetState(new HitState());
        (Character.State as HitState).TakeDamageData(_damage);
        Character.ChangeHealthLeft(-_damage.attackDamage);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterState : State
{
    public CharacterController Player { get; private set; }
    public override void Enter(StateMachine _machine, string _animationParameter = "")
    {
        base.Enter(_machine, _animationParameter);
        Player = Machine as CharacterController;
    }

    public virtual void TakeDamage(Damage _damage)
    {
        if (Player.HealthLeft <= 0) return;

        Player.SetState(new HitState());
        (Player.State as HitState).TakeDamageData(_damage);
        Player.ChangeHealthLeft(-_damage.attackDamage);
    }
}

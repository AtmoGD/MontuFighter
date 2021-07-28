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

    public virtual void TakeDamage(Damage _damage)
    {
        if(Player.HealthLeft <= 0) return;

        Player.SetState(new PlayerHitState());
        (Player.State as PlayerHitState).TakeDamageData(_damage);
        Player.ChangeHealthLeft(-_damage.attackDamage);
    }
}

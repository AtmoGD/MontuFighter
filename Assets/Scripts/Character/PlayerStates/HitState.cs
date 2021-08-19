using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitState : CharacterState
{
    private float getHitTimeLeft;
    private Damage damage;
    public override void Enter(StateMachine _machine, string _animationParameter = "GetHit")
    {
        base.Enter(_machine, "GetHit");
        getHitTimeLeft = Character.GetData().getHitTime;
    }

    public override void UpdateFrame()
    {
        base.UpdateFrame();

        getHitTimeLeft -= Time.deltaTime;
        if (getHitTimeLeft <= 0f)
        {
            Character.SetState(new StunnedState());
            (Character.State as StunnedState).TakeDamageData(damage);
        }
    }

    public void TakeDamageData(Damage _damage)
    {
        damage = _damage;
    }

    public override void TakeDamage(Damage _damage)
    {
        if (Character.HealthLeft <= 0) return;

        Character.ChangeHealthLeft(-_damage.attackDamage);
    }

}

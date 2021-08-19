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
        getHitTimeLeft = Player.GetData().getHitTime;
    }

    public override void UpdateFrame()
    {
        base.UpdateFrame();

        getHitTimeLeft -= Time.deltaTime;
        if (getHitTimeLeft <= 0f)
        {
            Player.SetState(new StunnedState());
            (Player.State as StunnedState).TakeDamageData(damage);
        }
    }

    public void TakeDamageData(Damage _damage)
    {
        damage = _damage;
    }

    public override void TakeDamage(Damage _damage)
    {
        if (Player.HealthLeft <= 0) return;

        Player.ChangeHealthLeft(-_damage.attackDamage);
    }

}

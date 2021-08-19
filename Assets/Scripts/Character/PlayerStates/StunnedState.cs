using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunnedState : CharacterState
{
    private float stunTimeLeft = -1f;
    private Damage damage;
    private GameObject stunnedObject;
    public override void Enter(StateMachine _machine, string _animationParameter = "Stunned")
    {
        base.Enter(_machine, "Stunned");
        stunnedObject = Player.InstantiateObject(Player.GetEffectLib().effects.Find(name => name.name == "Stunned").prefab, Player.transform);
    }

    public override void UpdateFrame()
    {
        base.UpdateFrame();
        if (stunTimeLeft == -1f) return;

        stunTimeLeft -= Time.deltaTime;
        if (stunTimeLeft <= 0)
            Player.SetState(new IdleState());
    }

    public void TakeDamageData(Damage _damage)
    {
        damage = _damage;
        stunTimeLeft = _damage.stunTime;
    }

    public override void TakeDamage(Damage _damage)
    {
        if (Player.HealthLeft <= 0) return;

        Player.ChangeHealthLeft(-_damage.attackDamage);
    }

    public override void Exit()
    {
        base.Exit();
        Player.DestroyObject(stunnedObject);
    }
}

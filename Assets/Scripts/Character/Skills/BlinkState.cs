using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkState : CharacterState
{
    private GameObject blinkObject;
    public override void Enter(StateMachine _machine, string _animationParameter = "Blink")
    {
        base.Enter(_machine, "Blink");
        
        if (Character.HasCoolDown(_animationParameter))
        {
            Character.SetState(new IdleState());
            return;
        }

        Character.AddCoolDown(new Cooldown(_animationParameter, Character.GetSkillData().blinkCoolDown));

        Blink();

        Effect effect = Character.GetEffectLib().effects.Find(x => x.name == animationParameter);
        if (effect.prefab != null) {
            blinkObject = Character.InstantiateObject(effect.prefab, Character.transform);
        }

        Character.SetState(new IdleState());
    }

    public void Blink()
    {
        float blinkDistance = Character.GetSkillData().blinkDistance;
        Vector3 direction = Character.transform.forward;
        Vector3 newPosition = Character.transform.position + direction * blinkDistance;
        if(Physics.Raycast(Character.transform.position + Vector3.up * 0.5f, direction, out RaycastHit hit, blinkDistance))
            newPosition = hit.point + -(direction.normalized * 0.5f);

        Character.rb.MovePosition(newPosition);
    }
}

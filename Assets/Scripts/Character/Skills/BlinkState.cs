using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkState : CharacterState
{
    private GameObject blinkObjectStart;
    private GameObject blinkObjectEnd;
    private float waitTime;
    public override void Enter(StateMachine _machine, string _animationParameter = "Blink")
    {
        base.Enter(_machine, "Blink");
        
        if (Character.HasCoolDown(_animationParameter))
        {
            Character.SetState(new IdleState());
            return;
        }

        Character.AddCoolDown(new Cooldown(_animationParameter, Character.GetSkillData().blinkCoolDown));

        waitTime = Character.GetSkillData().blinkWaitTime;

        Effect effect = Character.GetEffectLib().effects.Find(x => x.name == animationParameter);
        if (effect.prefab != null) {
            blinkObjectStart = Character.InstantiateObject(effect.prefab, Character.transform.position + Character.transform.forward, Character.transform.rotation);
            blinkObjectEnd = Character.InstantiateObject(effect.prefab, GetDestination(), Quaternion.identity);
        }

        // Character.SetState(new IdleState());
    }

    public Vector3 GetDestination()
    {
        float blinkDistance = Character.GetSkillData().blinkDistance;
        Vector3 direction = Character.transform.forward;
        Vector3 newPosition = Character.transform.position + direction * blinkDistance;
        if(Physics.Raycast(Character.transform.position + Vector3.up * 0.5f, direction, out RaycastHit hit, blinkDistance))
            newPosition = hit.point + -(direction.normalized * 0.5f);
        return newPosition;
    }

    public void Blink()
    {
        // float blinkDistance = Character.GetSkillData().blinkDistance;
        // Vector3 direction = Character.transform.forward;
        // Vector3 newPosition = Character.transform.position + direction * blinkDistance;
        // if(Physics.Raycast(Character.transform.position + Vector3.up * 0.5f, direction, out RaycastHit hit, blinkDistance))
        //     newPosition = hit.point + -(direction.normalized * 0.5f);

        Character.rb.MovePosition(GetDestination());
    }

    public override void UpdateFrame()
    {
        base.UpdateFrame();

        waitTime -= Time.deltaTime;
        if (waitTime <= 0)
        {
            Blink();
            Character.SetState(new IdleState());
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballState : CharacterState
{
    // private GameObject fireballObject;
    public override void Enter(StateMachine _machine, string _animationParameter = "Fireball")
    {
        base.Enter(_machine, "Fireball");
        
        if (Character.HasCoolDown(_animationParameter))
        {
            Character.SetState(new IdleState());
            return;
        }

        Character.AddCoolDown(new Cooldown(_animationParameter, Character.GetSkillData().fireballCoolDown));

        Effect effect = Character.GetEffectLib().effects.Find(x => x.name == animationParameter);
        if (effect.prefab != null) {
            GameObject fireballObject = Character.InstantiateObject(effect.prefab, Character.animator.transform.position, Character.animator.transform.rotation);
            fireballObject.GetComponent<FireballController>()?.TakeController(Character);
        }

        Character.SetState(new MovementState());
    }
}

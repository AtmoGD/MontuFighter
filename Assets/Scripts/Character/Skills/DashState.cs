using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashState : CharacterState
{
    private float distanceLeft = 0f;
    private Vector3 lastPos;
    private GameObject dashObject;
    public override void Enter(StateMachine _machine, string _animationParameter = "Dash")
    {
        base.Enter(_machine, "Dash");

        if (Character.HasCoolDown(animationParameter))
        {
            Character.SetState(new IdleState());
            return;
        }

        Character.AddCoolDown(new Cooldown(animationParameter, Character.GetSkillData().dashCoolDown));

        lastPos = Character.rb.transform.position;
        distanceLeft = Character.GetData().skillMultiplier * Character.GetSkillData().dashDistance;

        Effect effect = Character.GetEffectLib().effects.Find(x => x.name == animationParameter);
        if (effect.prefab != null)
            dashObject = Character.InstantiateObject(effect.prefab, Character.rb.transform);
    }

    public override void UpdateFrame()
    {
        base.UpdateFrame();

        Dash();

        distanceLeft -= (Character.transform.position - lastPos).magnitude;
        lastPos = Character.transform.position;

        if (distanceLeft <= 0f)
            Character.SetState(new IdleState());
    }

    public override void Exit()
    {
        base.Exit();

        Character.DestroyObject(dashObject);
    }

    public void Dash()
    {
        Vector3 lookAtPos = Character.rb.transform.position;
        lookAtPos += Character.rb.transform.forward;
        Character.rb.transform.LookAt(lookAtPos);

        Character.rb.velocity = Character.rb.transform.forward * Character.GetData().skillMultiplier * Character.GetSkillData().dashMovementSpeed;
    }

    public override void OnCollisionEnter(Collision _collision)
    {
        CheckCollision(_collision);
    }

    public override void OnCollisionStay(Collision _collision)
    {
        CheckCollision(_collision);
    }
    public void CheckCollision(Collision _collision)
    {
        if (_collision.gameObject.CompareTag("Ground"))
            return;

        Attackable enemy = _collision.collider.GetComponent<Attackable>();

        //Add take force to Attackable
        if (enemy != null)
        {
            enemy.TakeDamage(Character.GetDamage(Character.GetSkillData().dashAttackDamage, Character.GetSkillData().dashStunTime));
            Vector3 dir = (_collision.collider.transform.position - Character.transform.position).normalized;
            _collision.gameObject.GetComponent<Rigidbody>().AddForce(dir * Character.GetSkillData().dashHitForce);
            Character.rb.AddForce(-dir * Character.GetData().collideBackForce);
        }

        Character.SetState(new IdleState());
    }
}


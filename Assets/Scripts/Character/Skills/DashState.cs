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

        if (Player.HasCoolDown(_animationParameter))
        {
            Player.SetState(new IdleState());
            return;
        }

        Player.AddCoolDown(new Cooldown(_animationParameter, Player.GetSkillData().dashCoolDown));

        lastPos = Player.transform.position;
        distanceLeft = Player.GetData().skillMultiplier * Player.GetSkillData().dashDistance;
        dashObject = Player.InstantiateObject(Player.GetEffectLib().effects.Find(name => name.name == "Dash").prefab, Player.transform);
    }

    public override void UpdateFrame()
    {
        base.UpdateFrame();

        Dash();

        distanceLeft -= (Player.transform.position - lastPos).magnitude;
        lastPos = Player.transform.position;

        if (distanceLeft <= 0f)
            Player.SetState(new IdleState());
    }

    public override void Exit()
    {
        base.Exit();

        Player.DestroyObject(dashObject);
    }

    public void Dash()
    {
        Vector3 lookAtPos = Player.transform.position;
        lookAtPos += Player.transform.forward;
        // lookAtPos.x += Player.Inputs.Movement.x;
        // lookAtPos.z += Player.Inputs.Movement.y;
        Player.transform.LookAt(lookAtPos);

        Player.rb.velocity = Player.transform.forward * Player.GetData().skillMultiplier * Player.GetSkillData().dashMovementSpeed;
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
            enemy.TakeDamage(Player.GetDamage(Player.GetSkillData().dashAttackDamage, Player.GetSkillData().dashStunTime));
            Vector3 dir = (_collision.collider.transform.position - Player.transform.position).normalized;
            _collision.gameObject.GetComponent<Rigidbody>().AddForce(dir * Player.GetSkillData().dashHitForce);
            Player.rb.AddForce(-dir * Player.GetData().collideBackForce);
        }

        Player.SetState(new IdleState());
    }
}


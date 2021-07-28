using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerState
{
    private float distanceLeft = 0f;
    private Vector3 lastPos;
    public override void Enter(StateMachine _machine, string _animationParameter = "Dash")
    {
        base.Enter(_machine, "Dash");

        lastPos = Player.transform.position;
        distanceLeft = Player.GetData().skillMultiplier * Player.GetSkillData().dashDistance;
    }

    public override void UpdateFrame()
    {
        base.UpdateFrame();

        Dash();

        distanceLeft -= (Player.transform.position - lastPos).magnitude;
        lastPos = Player.transform.position;

        if (distanceLeft <= 0f)
            Player.SetState(new PlayerIdleState());
    }

    public void Dash()
    {
        Vector3 lookAtPos = Player.transform.position;
        lookAtPos.x += Player.Inputs.Movement.x;
        lookAtPos.z += Player.Inputs.Movement.y;
        Player.transform.LookAt(lookAtPos);

        Player.rb.velocity = Player.transform.forward * Player.GetData().skillMultiplier * Player.GetSkillData().dashMovementSpeed;
    }

    public override void OnCollisionEnter(Collision _collision) {
        Attackable enemy = _collision.collider.GetComponent<Attackable>();
        if (enemy != null) {
            enemy.TakeDamage(Player.GetDamage(Player.GetSkillData().dashAttackDamage, Player.GetSkillData().dashStunTime));
            Vector3 dir = (_collision.collider.transform.position - Player.transform.position).normalized;
            _collision.gameObject.GetComponent<Rigidbody>().AddForce(dir * Player.GetSkillData().dashHitForce);
        }

        Player.SetState(new PlayerIdleState());
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerState
{
    private float dashMovementSpeed = 10f;
    private float dashDistance = 10f;
    private float distanceLeft = 0f;
    private int attackDamage = 10;
    private float stunTime = 0.5f;
    private float dashHitForce = 100f;
    private Vector3 lastPos;
    public override void Enter(StateMachine _machine, string _animationParameter = "Dash")
    {
        base.Enter(_machine, "Dash");

        lastPos = Player.transform.position;
        distanceLeft = Player.GetData().skillMultiplier * dashDistance;
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

        Player.rb.velocity = Player.transform.forward * Player.GetData().skillMultiplier * dashMovementSpeed;
    }

    public override void OnCollisionEnter(Collision _collision) {
        Attackable enemy = _collision.collider.GetComponent<Attackable>();
        if (enemy != null) {
            enemy.TakeDamage(Player.GetDamage(attackDamage, stunTime));
            Vector3 dir = (_collision.collider.transform.position - Player.transform.position).normalized;
            _collision.gameObject.GetComponent<Rigidbody>().AddForce(dir * dashHitForce);
        }

        Player.SetState(new PlayerIdleState());
    }

    public override void Exit()
    {
        base.Exit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoState : CharacterState
{
    public override void Enter(StateMachine _machine, string _animationParameter = "Tornado")
    {
        base.Enter(_machine, "Tornado");
        
        if (Character.HasCoolDown(_animationParameter))
        {
            Character.SetState(new IdleState());
            return;
        }

        Character.AddCoolDown(new Cooldown(_animationParameter, Character.GetSkillData().tornadoCoolDown));

        Effect effect = Character.GetEffectLib().effects.Find(x => x.name == animationParameter);
        if (effect.prefab != null) {
            Debug.Log("Spawning effect");
            GameObject tornadoObject = Character.InstantiateObject(effect.prefab, Character.transform.position, Quaternion.identity);
            tornadoObject.GetComponent<TornadoController>().TakeController(Character);
            // tornadoObject.transform.localScale = Vector3.one * Character.GetSkillData().tornadoRadius;
        }

        Character.SetState(new IdleState());
    }
}
    // private GameObject tornadoObject;
    // public override void Enter(StateMachine _machine, string _animationParameter = "Tornado")
    // {
    //     base.Enter(_machine, "Tornado");

    //     if (Character.HasCoolDown(animationParameter))
    //     {
    //         Character.SetState(new IdleState());
    //         return;
    //     }

    //     Character.AddCoolDown(new Cooldown(animationParameter, Character.GetSkillData().tornadoCoolDown));

    //     tornadosLeft = Character.GetSkillData().tornadoWaves;
    //     tornadoWaveTime = Character.GetSkillData().tornadoWaveTime;
    //     actualWaveTime = Character.GetSkillData().tornadoWaveTime;

    //     Effect effect = Character.GetEffectLib().effects.Find(x => x.name == animationParameter);
    //     if (effect.prefab != null)
    //         tornadoObject = Character.InstantiateObject(effect.prefab, Character.transform.position, Quaternion.identity);
    // }

    // public override void UpdateFrame()
    // {
    //     base.UpdateFrame();

    //     actualWaveTime -= Time.deltaTime;
    //     if (actualWaveTime <= 0f)
    //     {
    //         Attack();
    //         tornadosLeft--;
    //         actualWaveTime = tornadoWaveTime;
    //     }

    //     if (tornadosLeft <= 0)
    //     {
    //         GameObject.Destroy(tornadoObject);
    //         Character.SetState(new IdleState());
    //     }
    //     // if (tornadosLeft <= 0f)
    //     //     Character.SetState(new IdleState());
    // }

    // public override void UpdatePhysics()
    // {
    //     base.UpdatePhysics();

    //     Move();
    // }

    // public override void Exit()
    // {
    //     Character.DestroyObject(tornadoObject);

    //     base.Exit();
    // }

    // public void Attack()
    // {
    //     RaycastHit[] hits = Physics.SphereCastAll(Character.transform.position, Character.GetSkillData().tornadoRadius, Character.transform.forward, Character.GetSkillData().tornadoRadius);
    //     if (hits.Length > 0)
    //     {
    //         foreach (RaycastHit hit in hits)
    //         {
    //             Attackable attackable = hit.transform.GetComponent<Attackable>();
    //             if (attackable != null && hit.collider.gameObject != Character.gameObject)
    //             {
    //                 Debug.Log("Tornado hit " + hit.transform.name);
    //                 attackable.TakeDamage(Character.GetDamage(Character.GetSkillData().tornadoDamage, Character.GetSkillData().tornadoStunTime));
                    
    //             }
    //         }
    //     }

    //     // Attackable attackable = Physics.Sp
    //     // Vector3 lookAtPos = Character.transform.position;
    //     // lookAtPos += Character.transform.forward;
    //     // Character.transform.LookAt(lookAtPos);

    //     // Character.rb.velocity = Character.transform.forward * Character.GetData().skillMultiplier * Character.GetSkillData().dashMovementSpeed;
    // }

    // public void Move()
    // {
    //     Vector3 lookAtPos = Character.transform.position;
    //     lookAtPos.x += Character.Inputs.Movement.x;
    //     lookAtPos.z += Character.Inputs.Movement.y;
    //     Character.transform.LookAt(lookAtPos);

    //     Vector3 desVel = Character.transform.forward * Character.GetData().movementSpeed;
    //     Vector3 newVel = Character.rb.velocity;
    //     newVel.x = desVel.x;
    //     newVel.z = desVel.z;

    //     Character.rb.velocity = Vector3.Lerp(Character.rb.velocity,  newVel, Character.GetData().movementVelocityChange);

    //     Character.State.SetAnimator(Character.GetData().animMoveSpeedName, Character.rb.velocity.magnitude * Character.GetData().speedAnimationMultiplier);

    //     // Player.animator.SetFloat(Player.GetData().animMoveSpeedName, Player.rb.velocity.magnitude * Player.GetData().speedAnimationMultiplier);
    // }

    // public override void OnCollisionEnter(Collision _collision)
    // {
    //     CheckCollision(_collision);
    // }

    // public override void OnCollisionStay(Collision _collision)
    // {
    //     CheckCollision(_collision);
    // }
    // public void CheckCollision(Collision _collision)
    // {
    //     if (_collision.gameObject.CompareTag("Ground"))
    //         return;

    //     Attackable enemy = _collision.collider.GetComponent<Attackable>();

    //     //Add take force to Attackable
    //     if (enemy != null)
    //     {
    //         enemy.TakeDamage(Character.GetDamage(Character.GetSkillData().dashAttackDamage, Character.GetSkillData().dashStunTime));
    //         Vector3 dir = (_collision.collider.transform.position - Character.transform.position).normalized;
    //         _collision.gameObject.GetComponent<Rigidbody>().AddForce(dir * Character.GetSkillData().dashHitForce);
    //         Character.rb.AddForce(-dir * Character.GetData().collideBackForce);
    //     }

    //     Character.SetState(new IdleState());
    // }
// }

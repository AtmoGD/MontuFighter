using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballController : MonoBehaviour
{
    public GameObject diePrefab;
    private Rigidbody rb;
    private CharacterController controller;
    private float speed;
    private float distance;
    private Vector3 lastPos;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        lastPos = transform.position;
    }
    private void FixedUpdate()
    {
        if (controller != null)
            MoveFireball();
    }
    private void MoveFireball()
    {
        rb.velocity = transform.forward * speed;

        distance -= (transform.position - lastPos).magnitude;
        if (distance < 0)
            Die();
    }
    private void Die()
    {
        rb.velocity = Vector3.zero;

        if (diePrefab)
            GameObject.Instantiate(diePrefab, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }

    public void TakeController(CharacterController _controller)
    {
        controller = _controller;
        speed = controller.GetSkillData().fireballMovementSpeed;
        distance = controller.GetSkillData().fireballDistance;
    }

    private void OnTriggerEnter(Collider _other)
    {
        if(controller == null) return;
        if(_other.gameObject == controller.gameObject) return;

        Attackable enemy = _other.GetComponent<Attackable>();

        //Add take force to Attackable
        if (enemy != null)
        {
            enemy.TakeDamage(controller.GetDamage(controller.GetSkillData().fireballAttackDamage, controller.GetSkillData().fireballStunTime));
            Vector3 dir = (_other.transform.position - controller.transform.position).normalized;
            _other.gameObject.GetComponent<Rigidbody>().AddForce(dir * controller.GetSkillData().fireballHitForce);
            // Character.rb.AddForce(-dir * controller.GetData().collideBackForce);
        }

        Die();
    }

}

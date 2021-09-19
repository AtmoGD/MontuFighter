using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoController : MonoBehaviour
{
    public GameObject diePrefab;
    public GameObject tornadoEffect;
    CharacterController character;
    private int tornadosLeft = 0;
    private float tornadoWaveTime = 0f;
    private float actualWaveTime = 0f;

    public void TakeController(CharacterController _character)
    {
        character = _character;
        tornadosLeft = character.GetSkillData().tornadoWaves;
        tornadoWaveTime = character.GetSkillData().tornadoWaveTime;
        actualWaveTime = tornadoWaveTime;

        float scale = character.GetSkillData().tornadoRadius;
        Vector3 localScale = transform.localScale;
        tornadoEffect.transform.localScale = new Vector3(localScale.x * scale, localScale.y * scale, localScale.z * scale);
    }

    private void Update()
    {
        if (character != null)
            Tick();
    }

    private void Tick()
    {
        if (tornadosLeft <= 0)
        {
            Die();
            return;
        }

        actualWaveTime -= Time.deltaTime;
        if (actualWaveTime <= 0)
        {
            actualWaveTime = tornadoWaveTime;
            tornadosLeft--;
            Attack();
        }
    }
    private void FixedUpdate()
    {
        if (character != null)
            MoveTowardTarget();
    }

    private void Attack()
    {
        RaycastHit[] hits = Physics.SphereCastAll(transform.position, character.GetSkillData().tornadoRadius, character.rb.transform.forward, character.GetSkillData().tornadoRadius);
        if (hits.Length > 0)
        {
            foreach (RaycastHit hit in hits)
            {
                Attackable attackable = hit.transform.GetComponent<Attackable>();
                if (attackable != null && hit.collider.gameObject != character.rb.gameObject)
                {
                    attackable.TakeDamage(character.GetDamage(character.GetSkillData().tornadoDamage, character.GetSkillData().tornadoStunTime));

                }
            }
        }
    }

    private void MoveTowardTarget()
    {
        if (character == null) return;
        Vector3 targetPosition = character.rb.transform.position;
        targetPosition.y = transform.position.y;
        transform.position = Vector3.Lerp(transform.position, targetPosition, character.GetSkillData().tornadoSpeedMultiplier * Time.deltaTime);
    }

    private void Die()
    {
        if (diePrefab)
            GameObject.Instantiate(diePrefab, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if (character != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, character.GetSkillData().tornadoRadius);
        }
    }
#endif
}

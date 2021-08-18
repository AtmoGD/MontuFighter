using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaObject : MonoBehaviour, Attackable
{
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody rb;
    [SerializeField] ArenaObjectData data;
    [SerializeField] public float health;
    private void Awake() {
        health = data.maxHealth;
    }
    public void TakeDamage(Damage _damage)
    {
        health -= _damage.attackDamage;

        SetAnimator(data.getHitAnimName);

        if (health <= 0)
            Die();
    }

    [ExecuteAlways]
    public void InstantiateDieObject() {
        Debug.Log("InstantiateDieObject");
        Instantiate(data.dieEffect, transform);
    }

    private void Die()
    {
        Destroy(rb);
        SetAnimator(data.dieAnimName);
    }

    private void SetAnimator(string _trigger)
    {
        if (animator)
            animator.SetTrigger(_trigger);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillData", menuName = "Data/SkillData")]
public class SkillData : ScriptableObject
{
    [Header("Dash")]
    public float dashMovementSpeed = 10f;
    public float dashDistance = 10f;
    public int dashAttackDamage = 10;
    public float dashStunTime = 0.5f;
    public float dashHitForce = 100f;
    public float dashCoolDown = 0.5f;

    [Header("Fireball")]
    public float fireballMovementSpeed = 10f;
    public float fireballDistance = 10f;
    public int fireballAttackDamage = 10;
    public float fireballStunTime = 0.5f;
    public float fireballHitForce = 100f;
    public float fireballCoolDown = 0.5f;
}

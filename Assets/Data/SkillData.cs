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

    [Header("Blink")]
    public float blinkDistance = 10f;
    public float blinkWaitTime = 0.1f;
    public float blinkCoolDown = 0.5f;

    [Header("Tornado")]
    public int tornadoWaves = 5;
    public float tornadoWaveTime = 0.2f;
    public int tornadoDamage = 5;
    public float tornadoSpeedMultiplier = 0.8f;
    public float tornadoStunTime = 0.5f;
    public float tornadoCoolDown = 0.5f;
    public float tornadoRadius = 5f;
}

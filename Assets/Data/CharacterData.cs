using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "Data/CharacterData")]
public class CharacterData : ScriptableObject
{
    [Header("Skill")]
    public int maxHealth = 100;
    public float skillMultiplier = 1.0f;
    public float getHitTime = 0.4f;
    public float stunResistance = 0.1f;

    [Header("Movement")]
    public float movementSpeed = 0.1f;
    public float movementVelocityChange = 0.1f;
    public string animMoveSpeedName = "MovementSpeed";

    [Header("Jump")]
    public float jumpForce = 10f;
    public float jumpMovementSpeed = 0.1f;
    public float jumpMovementVelocityChange = 0.1f;

    [Header("Other")]
    public float gravity = -0.1f;
    public float collideBackForce = 10f;
    public float speedAnimationMultiplier = 1.0f;
}

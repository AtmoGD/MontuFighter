using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "Data/CharacterData")]
public class CharacterData : ScriptableObject
{
    public int maxHealth = 100;
    public float skillMultiplier = 1.0f;
    public float stunResistance = 0.1f;
    public float movementSpeed = 0.1f;
    public float jumpMovementSpeed = 0.1f;
    public float jumpForce = 10f;
    public float getHitTime = 0.4f;
    public float gravity = -0.1f;
    public float collideBackForce = 10f;
    public float movementVelocityChange = 0.1f;
    public string animMoveSpeedName = "MovementSpeed";
    public float speedAnimationMultiplier = 1.0f;
}

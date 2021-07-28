using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Data/PlayerData")]
public class PlayerData : ScriptableObject
{
    public int maxHealth = 100;
    public float skillMultiplier = 1.0f;
    public float stunResistance = 0.1f;
    public float movementSpeed = 0.1f;
    public float jumpMovementSpeed = 0.1f;
    public float jumpForce = 10f;
    public float getHitTime = 0.4f;
}

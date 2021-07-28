using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage
{
    public PlayerController sender;
    public int attackDamage;
    public float stunTime;

    public Damage(PlayerController _sender, int _attackDamage, float _stunTime)
    {
        sender = _sender;
        attackDamage = _attackDamage;
        stunTime = _stunTime;
    }
}

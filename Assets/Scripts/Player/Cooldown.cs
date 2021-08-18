using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooldown
{
    public string name;
    public float left;

    public Cooldown(string _name, float _left)
    {
        this.name = _name;
        this.left = _left;
    }

    public void Remove(float _value)
    {
        this.left -= _value;
    }
}

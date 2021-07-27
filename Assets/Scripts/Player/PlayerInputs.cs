using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs
{
    public Vector2 Movement { get; set; }
    public bool Attack { get; set; }
    public bool Jump { get; set; }
    public PlayerInputs(Vector2 _movement = new Vector2(), bool _attack = false, bool _jump = false)
    {
        Movement = _movement;
        Attack = _attack;
        Jump = _jump;
    }
}
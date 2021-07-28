using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs
{
    public Vector2 Movement { get; set; }
    public bool Jump { get; set; }
    public bool AttackSkill { get; set; }
    public bool SupportSkill { get; set; }
    public PlayerInputs()
    {
        Movement = Vector2.zero;
        Jump = false;
        AttackSkill = false;
        SupportSkill = false;
    }
}
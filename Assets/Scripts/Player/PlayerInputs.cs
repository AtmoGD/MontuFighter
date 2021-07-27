using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs
{
    public Vector2 Movement { get; set; }
    public bool Jump { get; set; }
    public bool FirstSkill { get; set; }
    public bool SecondSkill { get; set; }
    public PlayerInputs()
    {
        Movement = Vector2.zero;
        Jump = false;
        FirstSkill = false;
        SecondSkill = false;
    }
}
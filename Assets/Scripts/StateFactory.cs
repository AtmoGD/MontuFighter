using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StateFactory
{
    public static State Create(Skill _skill)
    {
        switch (_skill)
        {
            case Skill.Dash:
                return new DashState();
            case Skill.Fireball:
                return new FireballState();
            default:
                return new IdleState();
        }
    }
}

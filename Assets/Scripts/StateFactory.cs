using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StateFactory
{
    public static State Create(PlayerSkill _skill)
    {
        switch (_skill)
        {
            case PlayerSkill.Dash:
                return new PlayerDashState();
            default:
                return new PlayerIdleState();
        }
    }
}

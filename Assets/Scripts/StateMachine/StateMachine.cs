using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    protected State state;
    
    StateMachine(State _state)
    {
        SetState(_state);
    }

    public void SetState(State _state)
    {
        state = _state;
        state.Enter();
    }
}

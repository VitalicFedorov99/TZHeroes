using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class FSM 
{
    private FSMState StateCurrent { get; set; }

    private Dictionary<Type, FSMState> states = new Dictionary<Type, FSMState>();

    public void SetState<T>() where T : FSMState 
    {
        var type = typeof(T);
        if (StateCurrent.GetType() == type)
            return;

        if(states.TryGetValue(type,out var newState))
        {
            StateCurrent?.Exit();
            StateCurrent = newState;
            StateCurrent.Enter();
        }
    }

    public void Update() 
    {
        StateCurrent?.Update();
    }
}

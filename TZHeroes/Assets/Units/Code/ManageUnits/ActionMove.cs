using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ActionUnits/ActionMoveTest", order = 1)]
public class ActionMove : ActionSO
{

    
    public override void Execute()
    {
        base.Execute();
        Move();
    }

    private void Move() 
    {
        Debug.Log("EscapeStep");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexWalkable : MonoBehaviour
{
    [SerializeField] private bool isWalkable;
    [SerializeField] private IStayInHex objectOnHex;


    public bool CheckWalkable() => isWalkable;

    public void SetWalkable(bool flag) => isWalkable = flag;

    public void ObjectEnterHex(IStayInHex obj)
    {
        objectOnHex = obj;
        isWalkable = false;
    }

    public void ObjectExitHex() 
    {
        objectOnHex = null;
        isWalkable = true;
    }
}

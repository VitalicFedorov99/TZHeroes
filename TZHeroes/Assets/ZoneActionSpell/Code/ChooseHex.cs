using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ZoneAction/ChooseHex")]
public class ChooseHex : ScriptableObject
{
    public Vector2Int CurrentPosition;
    public Hex currentHex;
}

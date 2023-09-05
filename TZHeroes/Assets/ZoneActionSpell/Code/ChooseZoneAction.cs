using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ZoneAction/ChooseZoneAction", order = 2)]
public class ChooseZoneAction : ScriptableObject
{
    public ZoneActionSpell ZoneAction;
    public Vector2Int CurrentPosition;
}

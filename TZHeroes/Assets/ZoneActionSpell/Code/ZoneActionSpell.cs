using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ZoneAction/ZoneActionSpell", order = 1)]
public class ZoneActionSpell : ScriptableObject
{
    public List<Vector2Int> Positions;
}

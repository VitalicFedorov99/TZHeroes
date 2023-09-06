using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/UnitStats/, order = 2)]
public class UnitStats : ScriptableObject
{
    public float Health;
    public float Movement;
    public RangeVariable DamageMelee;
    public float Initiative;
}

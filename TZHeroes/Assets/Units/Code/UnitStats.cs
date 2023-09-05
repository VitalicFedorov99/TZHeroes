using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/UnitStats/, order = 2)]
public class UnitStats : ScriptableObject
{
    [SerializeField] float Health;
    [SerializeField] float Movement;
    [SerializeField] RangeVariable DamageMelee;
    [SerializeField] float Initiative;
}

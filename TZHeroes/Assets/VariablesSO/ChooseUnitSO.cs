using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Varialable/ChooseUnitSO")]
public class ChooseUnitSO : ScriptableObject 
{
    public int countButton;
    public List<UnityAction> actions;
    public Squad currentSquad;
}

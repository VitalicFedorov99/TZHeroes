using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueFight : MonoBehaviour
{
    [SerializeField] private List<Squad> squads;
    [SerializeField] private GameEvent eventNextSquad;
    [SerializeField] private ChooseUnitSO chooseUnit;
    [SerializeField] private Squad currentSquad;

    int index = 0;


    public void Setup() 
    {
        index = -1;
        NextSquad();
    }
    public void NextSquad()
    {
        index++;
        if (index >= squads.Count) 
        {
            index = 0;
        }
        currentSquad = squads[index];
        chooseUnit.countButton = currentSquad.GetCountButton();
        chooseUnit.actions = currentSquad.GetUnityActions();
        chooseUnit.currentSquad = currentSquad;
        
        Debug.Log("следующий отряд");
        eventNextSquad.Raise();
    }
}

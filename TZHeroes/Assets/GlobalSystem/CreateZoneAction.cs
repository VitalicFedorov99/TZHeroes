using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateZoneAction : MonoBehaviour
{
    [SerializeField] private ChooseZoneAction chooseZoneAction;
    [SerializeField] private GameGrid grid;


    public void Debuger()
    {
        //GameGrid.OffColorize(); 
        //GameGrid.Colorize(chooseZoneAction.ZoneAction.Positions, chooseZoneAction.CurrentPosition);
    }
}

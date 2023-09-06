using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickHandlerStateMove : ClickHandler
{
    [SerializeField] private Squad currentSquad;

    [SerializeField] private ChooseUnitSO chooseUnit;
    [SerializeField] private ChooseHex chooseHex;

     private Hex hex;
    public override void Setup() 
    {
        currentSquad = chooseUnit.currentSquad;
        hex = null;
    }
    public override void Execute()
    {
        
        GameGrid.GetHex(chooseHex.CurrentPosition, out hex);
        if (hex != null)
            currentSquad.Move(hex);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickHandlerStateAttack : ClickHandler
{
    [SerializeField] private Squad currentSquad;
    [SerializeField] private ChooseUnitSO chooseUnit;
    [SerializeField] private ChooseEnemyUnit chooseEnemyUnit;
    [SerializeField] private FightManager fightManager;
    public override void Setup()
    {
        currentSquad = chooseUnit.currentSquad;
    }
    public override void Execute()
    {
        fightManager.SetSquadAttacking(currentSquad);
        fightManager.SetSquadDefencing(chooseEnemyUnit.EnemySquad);
        Debug.Log("ָהול בטעüסÿ");
        fightManager.Fight();
  //      GameGrid.GetHex(chooseHex.CurrentPosition, out hex);
   //     if (hex != null)
    //        currentSquad.Move(hex);
    }
}

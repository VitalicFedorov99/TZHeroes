using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightManager : MonoBehaviour
{
    [SerializeField] private Squad squadAttack;
    [SerializeField] private Squad squadDefense;
    [SerializeField] private GameEvent eventEndFight;

    private Hex hex;
    private List<Hex> hexes;
    public void SetSquadAttacking(Squad attacking)
    {
        squadAttack = attacking;
    }

    public void SetSquadDefencing(Squad defensing)
    {
        squadDefense = defensing;
    }

    public void Fight()
    {
        DefinitionTypeFight();
        EndFight();
    }


    private void DefinitionTypeFight()
    {
        Debug.Log(1);
        switch (squadAttack.GetFightComponent().GetComponent<IAttack>().AttackType)
        {
            case TypeAttack.MelleFight:
                MeleeFight();
                break;
            case TypeAttack.DistanceFight:
                DistantFight();
                break;
        }
    }

    private void MeleeFight()
    {
        ApproachToEnemy();
        /*squadAttack.GetComponent<IAttack>().AttackMelee(squadDefense.GetComponent<IDamage>());
        squadAttack.GetComponent<IDamage>().CheckDeath();
        squadDefense.GetComponent<IAttack>().AttackMelee(squadAttack.GetComponent<IDamage>());
        squadDefense.GetComponent<IDamage>().CheckDeath();*/
    }


    private void ApproachToEnemy()
    {
        if (CheckDistance())
        {
            Debug.Log(2);
            AStar.FindPath(squadAttack.GetHex(), hex, out hexes);
            hex = hexes[hexes.Count - 1];
            foreach(var h in hexes) 
            {
                h.OnColorize(Color.black);
            }
            //hex.OnColorize(Color.black);
        }
    }

    

    private bool CheckDistance()
    {
        AStar.FindNearestHex(squadAttack.GetHex(), squadDefense.GetHex(), out hex);
        Debug.LogError(hex);
        return squadAttack.CheckHex(hex);
    }

    private void DistantFight()
    {
        squadAttack.GetFightComponent().GetComponent<IAttack>().AttackDistance(squadDefense.GetFightComponent().GetComponent<IDamage>());
    }

    private void EndFight()
    {
        eventEndFight.Raise();
    }

}

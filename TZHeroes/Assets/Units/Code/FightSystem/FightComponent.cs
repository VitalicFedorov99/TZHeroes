using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FightComponent : MonoBehaviour, IAttack, IDamage
{

    [SerializeField] private TypeAttack typeAttack;
    [SerializeField] private GameEvent eventCancelAttack;

    private RangeVariable distanceAttack;
    private RangeVariable meleeAttack;
    private float healthOneUnit;
    private float countUnits;
    private float randDamage;
    [SerializeField] private float allHealth;

    public void Setup(UnitStats stats, int countUnits)
    {
        if (stats is RangeUnitStats)
        {
            var rangeStats = (RangeUnitStats)stats;
            distanceAttack = rangeStats.DamageRange;
            meleeAttack = rangeStats.DamageMelee;
            typeAttack = TypeAttack.DistanceFight;
        }
        else
        {
            typeAttack = TypeAttack.MelleFight;
        }
        healthOneUnit = stats.Health;
        this.countUnits = countUnits;
        allHealth = healthOneUnit * countUnits;

    }

    #region IAttack
    public TypeAttack AttackType => typeAttack;

    public void AttackDistance(IDamage objectDamage)
    {
        Debug.Log("—трел€ю");
        randDamage = Random.Range(distanceAttack.Min, distanceAttack.Max);
        objectDamage.TakeDamage(randDamage * countUnits);
    }

    public void AttackMelee(IDamage objectDamage)
    {
        Debug.Log("Ѕью рукой");
        randDamage = Random.Range(meleeAttack.Min, meleeAttack.Max);
        objectDamage.TakeDamage(randDamage * countUnits);
    }

    public void CancelAttack()
    {
        eventCancelAttack.Raise();
    }
    #endregion

    #region IDamage
    public bool CheckDeath()
    {
        if (countUnits <= 0)
            return true;
        return false;
    }

    public void DestroyObject()
    {

    }

    public void TakeDamage(float damage)
    {
        allHealth = countUnits * healthOneUnit;
        var tempHealth = allHealth - damage;
        var tempCount = Mathf.Ceil(tempHealth / healthOneUnit);
        countUnits = tempCount;
        Debug.Log("получил урон" + damage + "ќсталось в живых " + countUnits);
        CheckDeath();
    }
    #endregion
}

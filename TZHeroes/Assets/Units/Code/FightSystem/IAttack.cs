using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttack
{
    TypeAttack AttackType { get; }
    void CancelAttack();

    void AttackMelee(IDamage objectDamage);

    void AttackDistance(IDamage objectDamage);
}

public enum TypeAttack
{
    MelleFight,
    DistanceFight
}


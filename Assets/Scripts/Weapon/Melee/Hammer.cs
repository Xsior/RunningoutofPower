using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : WeaponBase
{

    public Hammer(WeaponManager parent) : base(parent)
    {

    }

    public override void Attack()
    {
        //base.Attack();
        if (parent.triggeredEnemy != null)
        {
            parent.triggeredEnemy.GetComponent<EnemyController>().DealDamage(50);
        }

    }
}

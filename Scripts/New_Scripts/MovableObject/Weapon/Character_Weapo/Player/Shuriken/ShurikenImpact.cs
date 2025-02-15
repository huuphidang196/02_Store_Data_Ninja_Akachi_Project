using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenImpact : WeaponCharacterImpact
{

    protected override void EventImpactEnter2D(GameObject col)
    {
        if (this.isImpact) return;

        base.EventImpactEnter2D(col);
    }
    protected override string[] GetArrayNameAllowImpact()
    {
        return new string[] { "Enemy", "ObjInteractableShuriken", "WeaponEnemy" };
    }

    protected override string[] GetArrayNameTargetAttack()
    {
        return new string[] { "Enemy" };
    }
}

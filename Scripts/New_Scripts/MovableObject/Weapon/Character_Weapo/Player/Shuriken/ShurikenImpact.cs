using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenImpact : WeaponCharacterImpact
{
    protected override string[] GetArrayNameAllowImpact()
    {
        return new string[] { "Enemy", "ObjInteractableShuriken", "WeaponEnemy" };
    }

    protected override string[] GetArrayNameTargetAttack()
    {
        return new string[] { "Enemy" };
    }
}

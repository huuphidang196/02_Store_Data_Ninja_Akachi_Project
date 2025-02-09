using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjTriigerImpactTargetPlayerAndHidenMode : WeaponCharacterImpact
{
    protected override string[] GetArrayNameTargetAttack()
    {
        return this.GetArrayNameAllowImpact();
    }
    protected override string[] GetArrayNameAllowImpact() => new string[] { "Player", "PlayerHiddenMode" };
}

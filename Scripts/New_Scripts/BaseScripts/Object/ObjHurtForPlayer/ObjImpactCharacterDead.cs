using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjImpactCharacterDead : ObjImpactTargetPlayerAndHidenModePlayer
{
    protected override bool CheckObjectImapactAllowedImpactCollision()
    {
        if (this._parentObj.gameObject.layer == LayerMask.NameToLayer("Enemy")) return true;

        return base.CheckObjectImapactAllowedImpactCollision();

    }
}

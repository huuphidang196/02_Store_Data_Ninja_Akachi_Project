using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjImpactTargetPlayerAndHidenModePlayer : ObjImpactTargetPlayer
{
    protected override bool CheckObjectImapactAllowedImpactCollision()
    {
        if (this._parentObj.gameObject.layer == LayerMask.NameToLayer("PlayerHiddenMode")) return true;

        return base.CheckObjectImapactAllowedImpactCollision();

    }
}

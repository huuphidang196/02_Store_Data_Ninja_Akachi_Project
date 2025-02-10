using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjImpactTargetPlayerAndHidenModePlayer : ObjImpactTargetPlayer
{
    protected override bool CheckObjectImapactAllowedImpact()
    {
        if (this.CheckParentObjectImpactWithAnyLayer("PlayerHiddenMode")) return true;
        return base.CheckObjectImapactAllowedImpact();
    }

}

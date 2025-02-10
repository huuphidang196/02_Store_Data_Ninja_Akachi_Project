using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjImpactCharacterDead : ObjImpactTargetPlayerAndHidenModePlayer
{
    protected override bool CheckObjectImapactAllowedImpact()
    {
        if (this.CheckParentObjectImpactWithAnyLayer("Enemy")) return true;
        return base.CheckObjectImapactAllowedImpact();
    }
}

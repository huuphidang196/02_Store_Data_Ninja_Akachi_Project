using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropImpact : ObjImpactTrigger
{
    protected override bool CheckConditionOverallAllowImpact()
    {
        if (this._parentObj.gameObject.layer == LayerMask.NameToLayer("Player")) return true;

        return false;
    }

    protected override void ProcessImpactTrigger()
    {
        this.ObjectCtrl.ObjDamageReceiver.DeductHP(9999f);
    }
}

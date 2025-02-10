using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropImpact : ObjImpactBoxColliderTrigger
{
    protected override void ProcessAfterObjectImpacted()
    {
        this.ObjectCtrl.ObjDamageReceiver.DeductHP(9999f);
    }

    protected override bool CheckObjectImapactAllowedImpact()
    {
        if (this._parentObj.gameObject.layer == LayerMask.NameToLayer("Player")) return true;

        return false;
    }

}

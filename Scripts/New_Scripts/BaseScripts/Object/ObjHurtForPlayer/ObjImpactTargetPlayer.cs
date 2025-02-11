using System.Collections;
using System.Collections.Generic;
using UnityEngine;

  
public class ObjImpactTargetPlayer : ObjImpactBoxColliderTrigger
{
    //  [Header("Object Impact Harmful")]

    protected override bool CheckObjectImapactAllowedImpact()
    {
        return this.CheckParentObjectImpactWithAnyLayer("Player");
    }

    protected override void ProcessAfterObjectImpacted()
    {
        //Send Damage to Player
        ObjDamageSender objDamSender = this._ObjectCtrl.ObjDamageSender;

        if (objDamSender == null) return;

        objDamSender.Send(this._parentObj);
    }
}

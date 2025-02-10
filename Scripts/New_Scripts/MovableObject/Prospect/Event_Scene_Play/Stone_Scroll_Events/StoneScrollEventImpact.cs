using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneScrollEventImpact : ObjImpactCircleColliderTrigger
{
    protected override bool CheckObjectImapactAllowedImpact()
    {
        return this.CheckParentObjectImpactWithAnyLayer(new string[] { "Player", "PlayerHiddenMode" });
    }

    protected override void ProcessAfterObjectImpacted()
    {
        //Send Damage to Player
        ObjDamageSender objDamSender = this._ObjectCtrl.ObjDamageSender;

        if (objDamSender == null) return;

        objDamSender.Send(this._parentObj);
    }
}

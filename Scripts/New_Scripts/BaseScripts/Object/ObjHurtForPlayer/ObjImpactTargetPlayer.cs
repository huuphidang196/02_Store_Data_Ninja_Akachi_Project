using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjImpactTargetPlayer : ObjImpactBoxCollider
{
    //  [Header("Object Impact Harmful")]

    protected override bool CheckObjectImapactAllowedImpactCollision()
    {
        // if (this._parentObj.gameObject.layer == LayerMask.NameToLayer("Player")) return true;
        if (this._parentObj.gameObject.layer == LayerMask.NameToLayer("Player")) return true;

        return false;

    }

    protected override void ProcessAfterObjectImapactCollision()
    {
        //Send Damage to Player
        ObjDamageSender objDamSender = this._ObjectCtrl.ObjDamageSender;

        if (objDamSender == null) return;

        objDamSender.Send(this._parentObj);
    }
}   

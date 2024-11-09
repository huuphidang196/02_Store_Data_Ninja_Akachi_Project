using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjImpactTargetPlayer : ObjImpact
{
    //  [Header("Object Impact Harmful")]

    protected override bool CheckObjectImapactAllowedImpactCollision()
    {
        // if (this._parentObj.gameObject.layer == LayerMask.NameToLayer("Player")) return true;
        if (this._parentObj.gameObject.layer == LayerMask.NameToLayer("Player")) return true;

        //if (this._parentObj.CompareTag("Inventory")) return false;

        //if (this._parentObj.CompareTag("VFX")) return false;

        //if (this._parentObj.CompareTag("Weapon")) return false;

        //if (this._parentObj.CompareTag("ItemDrop")) return false;

        //if (this._parentObj.CompareTag("SkillChoice")) return false;

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

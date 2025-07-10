using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBossImpact : ObjTriigerImpactTargetPlayerAndHidenMode
{
    protected override void ProcessAfterObjectImpacted()
    {
        // Debug.Log("name: " + this._parentObj.name + ", layer: " + LayerMask.LayerToName(this._parentObj.gameObject.layer));
        //Call OnDead in DamReceiver of Shuriken
        this.WeaponCharacterCtrl.ObjDamageSender.Send(this._parentObj);
        this._TypeImpact = TypeImpact.Emit_Blood;
        this.WeaponCharacterCtrl.WeaponCharacterDamReceiver.OnDeadByInfiniteDamage();



    }
}

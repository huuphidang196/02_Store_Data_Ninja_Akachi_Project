using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjImpactEmitGroundVFXTargetPlayerAndHiden : ObjImpactTargetPlayerAndHidenModePlayer
{
    protected override bool CheckObjectImapactAllowedImpact()
    {
        if (this.CheckParentObjectImpactWithAnyLayer("Ground")) return true;
        return base.CheckObjectImapactAllowedImpact();

    }
    protected override void ProcessAfterObjectImpacted()
    {
        base.ProcessAfterObjectImpacted();

        if (this.CheckParentObjectImpactWithAnyLayer("Ground"))
        {
            this.SpawnVFXWeaponByName(VFXObjectSpawner.VFX_Ground_Emit);
            return;
        }
    }

    protected virtual void SpawnVFXWeaponByName(string nameVFX)
    {
        Transform vfx_Need = VFXObjectSpawner.Instance.Spawn(nameVFX, this.transform.position, Quaternion.identity);

        if (vfx_Need == null) return;

        vfx_Need.localScale = this._ObjectCtrl.transform.localScale;
        vfx_Need.name = nameVFX;
        vfx_Need.gameObject.SetActive(true);

        Invoke(nameof(this.DelaySetImpact), 1f);

    }
    protected virtual void DelaySetImpact()
    {
        //Set NoImPact
        this.isImpact = false;
        this._parentObj = null;
    }    
}

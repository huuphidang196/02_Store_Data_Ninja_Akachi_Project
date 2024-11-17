using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCharacterVFXManager : WeaponCharacterAbstract
{
    public virtual void SpawnVFXIgniteFire()
    {
        this.SpawnVFXWeaponByName(VFXObjectSpawner.VFX_Ignite_Fire);
    }

    public virtual void SpawnVFXBloodEnemyEmit()
    {
        this.SpawnVFXWeaponByName(VFXObjectSpawner.VFX_Blood_Fly);
    }
    public virtual void SpawnVFXBGroundEmit()
    {
        this.SpawnVFXWeaponByName(VFXObjectSpawner.VFX_Ground_Emit);
    }
    public virtual void SpawnVFXWoodBoxEmit()
    {
        this.SpawnVFXWeaponByName(VFXObjectSpawner.VFX_WoodBox_Emit);
    }

  
    protected virtual void SpawnVFXWeaponByName(string nameVFX)
    {
        Transform vfx_Need = VFXObjectSpawner.Instance.Spawn(nameVFX, this.transform.position, Quaternion.identity);

        if (vfx_Need == null) return;

        vfx_Need.localScale = this._WeaponCharacterCtrl.transform.localScale;
        vfx_Need.name = nameVFX;
        vfx_Need.gameObject.SetActive(true);
    }    
}

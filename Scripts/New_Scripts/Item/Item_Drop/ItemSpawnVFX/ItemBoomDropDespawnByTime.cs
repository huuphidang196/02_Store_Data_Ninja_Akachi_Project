using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBoomDropDespawnByTime : ItemDropCreatVFXDespawnByTime
{
    protected override void ResetValue()
    {
        base.ResetValue();

        this._Delay = 1.2f;
    }
    protected override string GetNameVFXSpawn()
    {
        return VFXObjectSpawner.VFX_Boom_Explosion;
    }

}

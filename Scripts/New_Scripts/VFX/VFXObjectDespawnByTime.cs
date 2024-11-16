using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXObjectDespawnByTime : ObjDespawnByTime
{
    protected override void ResetValue()
    {
        base.ResetValue();

        this._Delay = 0.3f;

    }
    public override void DespawnObject()
    {
        VFXObjectSpawner.Instance.Despawn(this._ObjectCtrl.transform);
    }

}

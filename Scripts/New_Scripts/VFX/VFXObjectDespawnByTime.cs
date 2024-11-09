using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXObjectDespawnByTime : ObjDespawnByTime
{
    public override void DespawnObject()
    {
        VFXObjectSpawner.Instance.Despawn(this._ObjectCtrl.transform);
    }

}

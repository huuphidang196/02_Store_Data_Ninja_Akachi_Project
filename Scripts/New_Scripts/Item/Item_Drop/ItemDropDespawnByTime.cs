using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropDespawnByTime : ObjDespawnByTime
{
    public override void DespawnObject()
    {
        ItemDropSpawner.Instance.Despawn(this.GetParentObjectDespawn());

    }

    protected virtual Transform GetParentObjectDespawn() => this._ObjectCtrl.transform;

}

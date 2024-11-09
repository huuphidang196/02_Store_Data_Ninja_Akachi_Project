using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropCreatVFXDespawnByTime : ItemDropDespawnByTime
{
    public override void DespawnObject()
    {
        base.DespawnObject();

        this.SpawnVFXObjectByName(this.GetNameVFXSpawn());
    }

    protected virtual string GetNameVFXSpawn()
    {
        return "";
    }

    protected virtual void SpawnVFXObjectByName(string nameVFXObj)
    {
        Transform vfx = VFXObjectSpawner.Instance.Spawn(nameVFXObj, this._ObjectCtrl.transform.position, Quaternion.identity);

        if (vfx == null) return;

        vfx.gameObject.name = nameVFXObj;
        vfx.localScale = Vector3.one;
        vfx.gameObject.SetActive(true);
    }
}

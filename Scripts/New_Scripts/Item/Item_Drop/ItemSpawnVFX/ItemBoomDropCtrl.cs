using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBoomDropCtrl : ItemDropCtrl
{
    [SerializeField] protected ItemBoomDropDespawnByTime _ItemBoomDropDespawnByTime;
    public ItemBoomDropDespawnByTime ItemBoomDropDespawnByTime => this._ItemBoomDropDespawnByTime;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadItemBoomDropDespawnByTime();
    }

    protected virtual void LoadItemBoomDropDespawnByTime()
    {
        if (this._ItemBoomDropDespawnByTime != null) return;

        this._ItemBoomDropDespawnByTime = GetComponentInChildren<ItemBoomDropDespawnByTime>();
    }
}

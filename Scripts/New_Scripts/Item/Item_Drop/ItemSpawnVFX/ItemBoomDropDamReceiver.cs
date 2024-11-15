using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBoomDropDamReceiver : ItemDamReceiver
{
    [SerializeField] protected ItemBoomDropCtrl _ItemBoomDropCtrl => this._ObjectCtrl as ItemBoomDropCtrl;

    protected override void OnDead()
    {
        base.OnDead();

        this._ItemBoomDropCtrl.ItemBoomDropDespawnByTime.DespawnObject();   
    }
}

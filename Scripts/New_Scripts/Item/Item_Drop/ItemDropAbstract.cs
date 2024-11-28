using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropAbstract : SurMonoBehaviour
{
    [SerializeField] protected ItemDropCtrl _ItemDropCtrl;
    public ItemDropCtrl ItemDropCtrl => this._ItemDropCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadItemDropCtrl();
    }

    protected  virtual void LoadItemDropCtrl()
    {
        if (this._ItemDropCtrl != null) return;

        this._ItemDropCtrl = transform.parent.GetComponent<ItemDropCtrl>();
    }
}

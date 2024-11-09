using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextFlyingDespawnByTime : ItemDropDespawnByTime
{
    [Header("TextFlyingDespawnByTime")]
    [SerializeField] protected TextUICtrl _TextUICtrl;
 
    protected override void ResetValue()
    {
        base.ResetValue();

        this._Delay = 1.5f;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadTextFlyingCtrl();
    }

    protected virtual void LoadTextFlyingCtrl()
    {
        if (this._TextUICtrl != null) return;

        this._TextUICtrl = GetComponentInParent<TextUICtrl>();
    }

    protected override Transform GetParentObjectDespawn()
    {
        return this._TextUICtrl.transform;
    }
}

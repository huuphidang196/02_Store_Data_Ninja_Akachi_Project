using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisionsWaterFallManagerEnableOrDisableByDistance : ObjDisableOrEnableFollowTargetManager
{
    [SerializeField] protected PoisionWaterFallEventManager _PoisionWaterFallEventManager;

    protected override void ResetValue()
    {
        base.ResetValue();

        this.activationDistance = 45;
        this._Obj_Action = this._PoisionWaterFallEventManager.transform;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadPoisionWaterFallEventManager();
    }

    protected virtual void LoadPoisionWaterFallEventManager()
    {
        if (this._PoisionWaterFallEventManager != null) return;

        this._PoisionWaterFallEventManager = GetComponentInParent<PoisionWaterFallEventManager>();
    }

    protected override void ConductActionEvents()
    {
        this._PoisionWaterFallEventManager.SetActiveOrInActveAllWaterFall(this.activated);
    }
}

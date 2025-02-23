using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicProspectEnableByDistanceManager : ObjDisableOrEnableFollowTargetManager
{
    [SerializeField] protected DynamicMovementCtrl _DynamicMovementCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadDynamicMovementCtrl();
    }

    protected virtual void LoadDynamicMovementCtrl()
    {
        if (this._DynamicMovementCtrl != null) return;

        this._DynamicMovementCtrl = transform.Find("DynamicProspect_Bridge_Horizontal_Movement").GetComponent<DynamicMovementCtrl>();
        this._DynamicMovementCtrl.gameObject.SetActive(false);
    }

    protected override void ResetValue()
    {
        base.ResetValue();

        this.activationDistance = this._DynamicMovementCtrl.DynamicProspectObjMovementSO.Distance_Active;
        this._Obj_Action = this._DynamicMovementCtrl.transform;
    }

}

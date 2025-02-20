using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicBridgeMovement : ObjKinematicMovement
{

    [SerializeField] protected DynamicMovementCtrl _DynamicMovementCtrl;

    protected override void LoadComponents()
    {
        this.LoadDynamicMovementCtrl();

        base.LoadComponents();
    }

    protected virtual void LoadDynamicMovementCtrl()
    {
        if (this._DynamicMovementCtrl != null) return;

        this._DynamicMovementCtrl = GetComponentInParent<DynamicMovementCtrl>();
    }

    protected override void LoadRigidbody2D()
    {
        if (this._Rigidbody2D != null) return;

        this._Rigidbody2D = this._DynamicMovementCtrl.transform.GetComponent<Rigidbody2D>();
    }

    protected override float GetSpeedMoveHorizontal()
    {
        return 3f;
    }

    
}

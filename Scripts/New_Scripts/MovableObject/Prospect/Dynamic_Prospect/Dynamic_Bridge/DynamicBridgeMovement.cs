using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicBridgeMovement : ObjKinematicMovement
{

    [SerializeField] protected DynamicMovementCtrl _DynamicMovementCtrl;

    protected override void ResetValue()
    {
        base.ResetValue();

        this._Horizontal = this._Speed_Move_Horizontal;
    }
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
        this._Rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
        this._Rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionY;
    }

    protected override float GetSpeedMoveHorizontal()
    {
        return 3f;
    }

    
}

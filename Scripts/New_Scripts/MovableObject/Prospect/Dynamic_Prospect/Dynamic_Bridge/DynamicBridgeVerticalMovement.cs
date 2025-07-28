using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicBridgeVerticalMovement : DynamicBridgeMovement
{
    [SerializeField] protected bool MoveUp = true;
    public bool IsMoveUp => this.MoveUp;
    protected override void ResetValue()
    {
        base.ResetValue();
        this.MoveUp = true;
    }

    protected override void ResetDataConfiguration()
    {
       
    }
    protected override void Reset()
    {
        base.Reset();

        this._Speed_Move_Horizontal = this.GetSpeedMoveHorizontal();
        this._Horizontal = this._Speed_Move_Horizontal;

        this._Speed_Move_Vertical = this.GetSpeedMoveVertical(); 
        this._Vertical = this._Speed_Move_Vertical;

        this._Old_Position = this.DynamicMovementCtrl.transform.position;
    }

    protected virtual float GetSpeedMoveVertical()
    {
        return this.DynamicMovementCtrl.DynamicProspectObjMovementSO.Speed_Move_Vertical;
    }

    protected virtual float GetSpeedMoveHorizontal()
    {
        return this.DynamicMovementCtrl.MObjScriptableObject.Speed_Move_Horizontal;
    }

    public override void ChangeDir()
    {
        this.MoveUp = !this.MoveUp;
        this._Vertical = this.MoveUp ? this._Speed_Move_Vertical : this._Speed_Move_Vertical * -1f;
    }

    protected override void FixedUpdate()
    {
        // Chuyển đổi hướng Y local thành hướng trong world space

        this._Rigidbody2D.velocity = this.DynamicMovementCtrl.gameObject.transform.up * this._Vertical;
    }
}

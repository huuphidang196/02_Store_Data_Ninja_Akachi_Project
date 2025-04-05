using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicBridgeVerticalMovement : DynamicBridgeMovement
{
    [SerializeField] protected bool MoveOn = true;

    protected override void ResetValue()
    {
        base.ResetValue();
        this.MoveOn = true;
    }

    protected override void ResetDataConfiguration()
    {
       
    }
    protected override void Reset()
    {
        base.Reset();

        this._Speed_Move_Horizontal = this.DynamicMovementCtrl.MObjScriptableObject.Speed_Move_Horizontal;
        this._Horizontal = this._Speed_Move_Horizontal;

        this._Speed_Move_Vertical = this.DynamicMovementCtrl.DynamicProspectObjMovementSO.Speed_Move_Vertical;
        this._Vertical = this._Speed_Move_Vertical;

        this._Old_Position = this.DynamicMovementCtrl.transform.position;
    }
    public override void ChangeDir()
    {
        this.MoveOn = !this.MoveOn;
        this._Vertical = this.MoveOn ? this._Speed_Move_Vertical : this._Speed_Move_Vertical * -1f;
    }

    protected override void FixedUpdate()
    {
        // Chuyển đổi hướng Y local thành hướng trong world space

        this._Rigidbody2D.velocity = this.DynamicMovementCtrl.gameObject.transform.up * this._Vertical;
    }
}

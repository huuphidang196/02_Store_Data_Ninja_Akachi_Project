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

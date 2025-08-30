using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicBridgeHorizontalMovement : DynamicBridgeMovement
{
    protected override void ResetDataConfiguration()
    {
        this._Speed_Move_Horizontal = this.DynamicMovementCtrl.MObjScriptableObject.Speed_Move_Horizontal;
        this._Horizontal = this._Speed_Move_Horizontal;

        this._Speed_Move_Vertical = this.DynamicMovementCtrl.DynamicProspectObjMovementSO.Speed_Move_Vertical;
        this._Vertical = this._Speed_Move_Vertical;

        this._Old_Position = this.DynamicMovementCtrl.transform.position;
    }

    protected override void LoadRigidbody2D()
    {
        base.LoadRigidbody2D();

        this._Rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionY;
    }

    public override void ChangeDir()
    {
        this._Move_Right = !this._Move_Right;
        this._Horizontal = this._Move_Right ? this._Speed_Move_Horizontal : this._Speed_Move_Horizontal * -1f;
    }
}

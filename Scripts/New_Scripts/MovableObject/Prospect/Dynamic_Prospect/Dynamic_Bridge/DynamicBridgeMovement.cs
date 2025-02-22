using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicBridgeMovement : MovableObjKinematicMovement
{
   public DynamicMovementCtrl DynamicMovementCtrl => this._MovableObjCtrl as DynamicMovementCtrl;
    protected override float GetSpeedMoveHorizontal()
    {
        return this.DynamicMovementCtrl.MObjScriptableObject.Speed_Move_Horizontal;
    }

    protected override void ResetDataConfiguration()
    {
        base.ResetDataConfiguration();

        this._Horizontal = this._Speed_Move_Horizontal;
    }
}

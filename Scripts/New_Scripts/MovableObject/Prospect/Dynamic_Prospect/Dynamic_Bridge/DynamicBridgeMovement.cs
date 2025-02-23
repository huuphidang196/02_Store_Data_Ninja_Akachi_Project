using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicBridgeMovement : MovableObjKinematicMovement
{
   public DynamicMovementCtrl DynamicMovementCtrl => this._MovableObjCtrl as DynamicMovementCtrl;

    [SerializeField] protected Vector3 _Old_Position;

    protected override float GetSpeedMoveHorizontal()
    {
        return this.DynamicMovementCtrl.MObjScriptableObject.Speed_Move_Horizontal;
    }

    protected override void ResetDataConfiguration()
    {
        base.ResetDataConfiguration();

        this._Horizontal = this._Speed_Move_Horizontal;
        this._Old_Position = this.DynamicMovementCtrl.transform.position;
    }

    protected override void Flip()
    {
        //must null
    }

}

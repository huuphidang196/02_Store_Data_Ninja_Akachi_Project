using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovableObjKinematicMovement : MovableObjectMovementFlip
{
    protected override void ResetDataConfiguration()
    {
        base.ResetDataConfiguration();
        this._Speed_Move_Horizontal = this.GetSpeedMoveHorizontal();
    }

    protected abstract float GetSpeedMoveHorizontal();


    protected override void LoadRigidbody2D()
    {
        base.LoadRigidbody2D();

        this._Rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
        this._Rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionY;
    }

    public virtual void ChangeDir()
    {
        this._Move_Right = !this._Move_Right;
        this._Horizontal = this._Move_Right ? this._Speed_Move_Horizontal : this._Speed_Move_Horizontal * -1f;
    }

    protected virtual void FixedUpdate()
    {
        this._Rigidbody2D.velocity = new Vector2(this._Horizontal, this._Rigidbody2D.velocity.y);
    }
}

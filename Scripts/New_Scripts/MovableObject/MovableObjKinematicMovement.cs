using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovableObjKinematicMovement : MovableObjectMovementFlip
{
    [SerializeField] protected float _Vertical = 0f;
    [SerializeField] protected float _Speed_Move_Vertical = 0f;
    protected override void LoadRigidbody2D()
    {
        base.LoadRigidbody2D();

        this._Rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
       // this._Rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionY;
    }
    public virtual void ChangeDir()
    {
    }

    protected virtual void FixedUpdate()
    {
        this._Rigidbody2D.velocity = new Vector2(this._Horizontal, this._Vertical);
    }
}

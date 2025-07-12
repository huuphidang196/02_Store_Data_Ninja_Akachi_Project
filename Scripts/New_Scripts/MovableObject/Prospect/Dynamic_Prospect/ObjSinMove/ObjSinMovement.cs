using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjSinMovement : DynamicBridgeMovement
{
    [SerializeField] protected float amplitude = 6f;
    [SerializeField] protected float frequency = 0.4f;

    [SerializeField] protected Vector3 startPos;
    protected float traveledX = 0f;

    protected override void Start()
    {
        base.Start();

        startPos = this._MovableObjCtrl.transform.position;  // dùng rb.position thay cho transform.position
    }

    protected override void FixedUpdate()
    {
        float direction = this.Move_Right ? 1f : -1f;
        traveledX += this._Speed_Move_Horizontal * direction * Time.fixedDeltaTime;

        this._Rigidbody2D.MovePosition(startPos + this.GetXY());
    }

    protected virtual Vector3 GetXY()
    {
        return new Vector3(traveledX, amplitude * Mathf.Sin(frequency * traveledX), 0);
    }
    public override void ChangeDir()
    {
        base.ChangeDir();

        this._Move_Right = !this.Move_Right;
    }
}

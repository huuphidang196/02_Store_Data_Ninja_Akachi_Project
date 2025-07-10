using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowDarkMovement : ObjSinMovement
{
    protected Vector3 prevPos; // Vị trí cũ để tính vận tốc

    protected override void Start()
    {
        base.Start();
        prevPos = startPos;
    }

    protected override void FixedUpdate()
    {
        float direction = this.Move_Right ? 1f : -1f;
        traveledX += this._Speed_Move_Horizontal * direction * Time.fixedDeltaTime;

        Vector3 nextPos = startPos + this.GetXY();

        // Cập nhật vị trí
        this._Rigidbody2D.MovePosition(nextPos);

        // ✅ Tính vector vận tốc
        Vector3 velocity = (nextPos - prevPos) / Time.fixedDeltaTime;

        // ✅ Tính góc xoay theo hướng vận tốc (xoay quanh trục Z)
        float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;

        this._MovableObjCtrl.transform.rotation = Quaternion.Euler(0, 0, angle);

        // Cập nhật vị trí trước
        prevPos = nextPos;
    }

    public virtual void SetDirection(Transform objectSpawn)
    {
        this._Move_Right = objectSpawn.localScale.x > 0;
    }

    public virtual float GetDistanceXMoved() => Mathf.Abs(this._MovableObjCtrl.transform.position.x - this.startPos.x);
}

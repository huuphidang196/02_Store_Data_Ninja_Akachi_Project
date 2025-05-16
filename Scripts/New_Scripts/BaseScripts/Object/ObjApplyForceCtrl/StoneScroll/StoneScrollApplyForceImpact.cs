using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneScrollApplyForceImpact : ObjApplyForceAfterImpact
{
    [SerializeField] protected bool isScrolling = false;

    public override void ApplyForce(Vector3 pointImpacted, Vector3 forceDirection)
    {
        base.ApplyForce(pointImpacted, forceDirection);
        // Áp dụng lực tại điểm va chạm
        if (this.ObjApplyForceCtrl.Rigidbody2D== null) return;
      
        this.isScrolling = true;

        Invoke(nameof(this.StopScroll), 3f);
    }

    protected virtual void StopScroll()
    {
        this.isScrolling = false;
    }

    //protected virtual void FixedUpdate()
    //{
    //    if (isScrolling) return;

    //    if (this.ObjApplyForceCtrl.Rigidbody2D == null) return;

    //    this.ObjApplyForceCtrl.Rigidbody2D.velocity = new Vector2(0, this.ObjApplyForceCtrl.Rigidbody2D.velocity.y);
    //}
}

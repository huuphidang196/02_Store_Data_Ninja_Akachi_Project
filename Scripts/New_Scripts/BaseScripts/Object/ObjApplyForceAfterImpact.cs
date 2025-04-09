using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjApplyForceAfterImpact : ObjectAbstract
{
    public ObjApplyForceCtrl ObjApplyForceCtrl => this._ObjectCtrl as ObjApplyForceCtrl;

    [SerializeField] protected float forceMultiplier = 2f; // Hệ số lực tùy chỉnh

    public virtual void ApplyForce(Vector3 pointImpacted, Vector3 forceDirection)
    {
        // Áp dụng lực tại điểm va chạm
        if (this.ObjApplyForceCtrl.Rigidbody2D == null) return;

        this.ObjApplyForceCtrl.Rigidbody2D.AddForceAtPosition(forceDirection * forceMultiplier, pointImpacted, ForceMode2D.Impulse);

    }
  
}

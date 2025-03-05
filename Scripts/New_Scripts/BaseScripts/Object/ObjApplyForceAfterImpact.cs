using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjApplyForceAfterImpact : ObjectAbstract
{
    [SerializeField] protected float forceMultiplier = 2f; // Hệ số lực tùy chỉnh

    public virtual void ApplyForce(Vector3 pointImpacted, Vector3 forceDirection)
    {
        // Áp dụng lực tại điểm va chạm
        if (this._ObjectCtrl.GetComponent<Rigidbody2D>() == null) return;

        Rigidbody2D rig = this._ObjectCtrl.GetComponent<Rigidbody2D>();

        rig.AddForceAtPosition(forceDirection * forceMultiplier, pointImpacted, ForceMode2D.Impulse);
    }    
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjImpactBoxColliderTrigger : ObjImpactBoxCollider
{  
    protected override void LoadBoxCollider2D()
    {
        base.LoadBoxCollider2D();
        this._boxCollider.isTrigger = true;
    }

    protected override void LoadRigidbody2D()
    {
        base.LoadRigidbody2D();

        this._Rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
    }

    protected virtual void OnTriggerEnter2D(Collider2D collider2D)
    {
        this.EventImpactEnter2D(collider2D.gameObject);
    }

 
}

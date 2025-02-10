using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjImpactCircleColliderTrigger : ObjImpactCircleCollider
{
    protected override void LoadCircleCollider2D()
    {
        base.LoadCircleCollider2D();
        this._CircleCollider2D.isTrigger = true;
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

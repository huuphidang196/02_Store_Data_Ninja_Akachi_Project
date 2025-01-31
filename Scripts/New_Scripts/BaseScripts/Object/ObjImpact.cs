using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]

public class ObjImpact : ObjImpactOverall
{
    [Header("Object Impact")]

    // [SerializeField] protected float _maxRadius = 2f;
    [SerializeField] protected Rigidbody2D _Rigidbody2D;
    [SerializeField] protected BoxCollider2D _boxCollider;
    public BoxCollider2D BoxCollider2D => this._boxCollider;
    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadCollider2D();
        this.LoadRigidbody2D();
    }

    protected virtual void LoadCollider2D()
    {
        if (this._boxCollider != null) return;

        this._boxCollider = GetComponent<BoxCollider2D>();
        //  this._boxCollider.isTrigger = true;
    }

    protected virtual void LoadRigidbody2D()
    {
        if (this._Rigidbody2D != null) return;

        this._Rigidbody2D = GetComponent<Rigidbody2D>();
        //this._rigidbody.isKinematic = true;
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        this.EventImpactEnter2D(collision.gameObject);
        // Debug.Log(transform.name + " Impact " + collision.transform.name);
    }

    protected override void ProcessAfterObjectImapactCollision()
    {

    }
}

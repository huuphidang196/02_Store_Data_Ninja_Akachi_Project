using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class StaticBridgeCtrl : ObjectCtrl
{
    public StaticBridgeImpactDrop _StaticBridgeImpactDrop => this._ObjImpact_Overall as StaticBridgeImpactDrop;

    [SerializeField] protected StaticBridgeProspectDropping _StaticBridgeProspectDropping;
    public StaticBridgeProspectDropping StaticBridgeProspectDropping => this._StaticBridgeProspectDropping;

    [SerializeField] protected Rigidbody2D _Rigidbody2D;
    public Rigidbody2D Rigidbody2D => this._Rigidbody2D;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadStaticBridgeProspectDropping();
        this.LoadRigidbody2D();
    }

    protected virtual void LoadStaticBridgeProspectDropping()
    {
        if (this._StaticBridgeProspectDropping != null) return;

        this._StaticBridgeProspectDropping = GetComponentInChildren<StaticBridgeProspectDropping>();
    }

    protected virtual void LoadRigidbody2D()
    {
        if (this._Rigidbody2D != null) return;

        this._Rigidbody2D = GetComponent<Rigidbody2D>();
        this._Rigidbody2D.bodyType = RigidbodyType2D.Static;
    }

}

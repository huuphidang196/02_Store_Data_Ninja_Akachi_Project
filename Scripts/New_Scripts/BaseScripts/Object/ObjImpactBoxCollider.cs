using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class ObjImpactBoxCollider : ObjImpactBasement
{
    [Header("ObjImpactBoxCollider")]

    [SerializeField] protected BoxCollider2D _boxCollider;
    public BoxCollider2D BoxCollider2D => this._boxCollider;
    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadBoxCollider2D();
    }

    protected virtual void LoadBoxCollider2D()
    {
        if (this._boxCollider != null) return;

        this._boxCollider = GetComponent<BoxCollider2D>();
    }

    protected override void ProcessAfterObjectImpacted()
    {

    }

    protected override bool CheckObjectImapactAllowedImpact()
    {
        return true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class ObjImpactCircleCollider : ObjImpactBasement
{
    [Header("ObjImpactCircleCollider")]

    [SerializeField] protected CircleCollider2D _CircleCollider2D;
    public CircleCollider2D CircleCollider2D => this._CircleCollider2D;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadCircleCollider2D();
    }

    protected virtual void LoadCircleCollider2D()
    {
        if (this._CircleCollider2D != null) return;

        this._CircleCollider2D = GetComponent<CircleCollider2D>();      
    }

    protected override void ProcessAfterObjectImpacted()
    {

    }

    protected override bool CheckObjectImapactAllowedImpact()
    {
        return true;
    }
}


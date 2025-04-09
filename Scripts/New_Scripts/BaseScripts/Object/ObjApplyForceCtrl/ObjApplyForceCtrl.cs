using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjApplyForceCtrl : ObjectCtrl
{
    [SerializeField]
    protected Rigidbody2D _Rig;

    public Rigidbody2D Rigidbody2D => this._Rig;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadRigidbody2D();
    }

    protected virtual void LoadRigidbody2D()
    {
        if (this._Rig != null) return;

        this._Rig = GetComponent<Rigidbody2D>();
    }
}

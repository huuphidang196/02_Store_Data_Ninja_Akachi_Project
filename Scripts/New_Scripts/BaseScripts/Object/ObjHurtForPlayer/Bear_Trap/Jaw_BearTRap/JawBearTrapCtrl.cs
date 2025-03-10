using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JawBearTrapCtrl : ObjectCtrl
{
    [SerializeField] protected ObjActionNip _ObjActionNip;
    public ObjActionNip ObjActionNip => this._ObjActionNip;

    [SerializeField] protected ObjActionNipIndependantManager _ObjActionNipIndependantManager;
    public ObjActionNipIndependantManager ObjActionNipIndependantManager => this._ObjActionNipIndependantManager;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadObjActionNip();
        this.LoadObjActionNipIndependantManager();
    }

    protected virtual void LoadObjActionNipIndependantManager()
    {
        if (this._ObjActionNipIndependantManager != null) return;

        this._ObjActionNipIndependantManager = GetComponentInParent<ObjActionNipIndependantManager>();
    }

    protected virtual void LoadObjActionNip()
    {
        if (this._ObjActionNip != null) return;

        this._ObjActionNip = transform.Find("ObjActionNip").GetComponent<ObjActionNip>();
    }
}

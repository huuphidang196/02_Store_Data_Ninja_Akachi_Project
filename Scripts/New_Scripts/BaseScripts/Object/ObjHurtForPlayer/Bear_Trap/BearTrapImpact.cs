using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearTrapImpact : ObjImpactTargetPlayerAndHidenModePlayer
{
    [SerializeField] protected ObjActionNip _ObjActionNip;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadObjActionNip();
    }

    protected virtual void LoadObjActionNip()
    {
        if (this._ObjActionNip != null) return;

        this._ObjActionNip = GetComponentInParent<ObjActionNip>();
    }

    protected override void EventImpactEnter2D(GameObject col)
    {
        //base.EventImpactEnter2D(col);

        this._ObjActionNip.CloseTrap();
    }
}

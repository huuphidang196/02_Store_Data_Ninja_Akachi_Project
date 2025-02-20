using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicMovementCtrl : ObjectCtrl
{
    [SerializeField] protected ObjKinematicMovement _ObjKinematicMovement;
    public ObjKinematicMovement ObjKinematicMovement => this._ObjKinematicMovement;


    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadObjKinematicMovement();
    }

    protected virtual void LoadObjKinematicMovement()
    {
        if (this._ObjKinematicMovement != null) return;

        this._ObjKinematicMovement = GetComponentInChildren<ObjKinematicMovement>();
    }
}

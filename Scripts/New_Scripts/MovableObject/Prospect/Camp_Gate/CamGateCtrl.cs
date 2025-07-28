using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamGateCtrl : DynamicMovementCtrl
{
    [SerializeField] protected CamGateCheckControl _CamGateCheckControl;
    public CamGateCheckControl CamGateCheckControl => this._CamGateCheckControl;

    public CamGateMovement CamGateMovement => this._MovableObj_Movement as CamGateMovement;
    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadCamGateCheckControl();
    }

    protected virtual void LoadCamGateCheckControl()
    {
        if (this._CamGateCheckControl != null) return;

        this._CamGateCheckControl = GetComponentInChildren<CamGateCheckControl>();
    }
}

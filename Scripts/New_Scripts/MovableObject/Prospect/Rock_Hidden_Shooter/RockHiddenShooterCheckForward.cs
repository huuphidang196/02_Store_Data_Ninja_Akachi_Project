using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockHiddenShooterCheckForward : CharacterCheckForward
{
    [SerializeField] protected RockHiddenShooterCtrl _RockHiddenShooterCtrl;


    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadRockHiddenShooterCtrl();
    }

    protected virtual void LoadRockHiddenShooterCtrl()
    {
        if (this._RockHiddenShooterCtrl != null) return;

        this._RockHiddenShooterCtrl = GetComponentInParent<RockHiddenShooterCtrl>();
    }

    protected override void ResetValue()
    {
        this.LoadLayerMaskForward();

        this._Length_Raycast = 15f;
    }

    protected override void LoadLayerMaskForward()
    {
        if (this._ObjForwardLayer.Length > 0) return;

        this._ObjForwardLayer = new string[1];
        this._ObjForwardLayer[0] = "Player";
    }
    protected override void FixedUpdate()
    {
        this.ProcessFixedUpdateEvent();
    }
    protected override Vector2 GetDirectionRaycast()
    {
        return -1f * this._RockHiddenShooterCtrl.transform.right * this._Length_Raycast;
    }
}

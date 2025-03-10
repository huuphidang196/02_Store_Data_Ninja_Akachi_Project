using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearTrapCtrl : ObjectCtrl
{
    [SerializeField] protected Transform _VFX_Stun;
    public Transform VFX_Stun => this._VFX_Stun;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadVFXStun();
    }

    protected virtual void LoadVFXStun()
    {
        if (this._VFX_Stun != null) return;

        this._VFX_Stun = transform.Find("VFX_Stun");
        this._VFX_Stun.gameObject.SetActive(false);
    }
}

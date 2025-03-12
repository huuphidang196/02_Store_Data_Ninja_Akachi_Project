using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearTrapCtrl : ObjectCtrl
{
    [Header("BearTrapCtrl")]

    [SerializeField] protected Transform _VFX_Stun;
    public Transform VFX_Stun => this._VFX_Stun;

    [SerializeField] protected ObjActionNipIndependantManager _ObjActNipManager;
    public ObjActionNipIndependantManager ObjActionNipIndependantManager => this._ObjActNipManager;

    [SerializeField] protected ObjDespawnByTime _ObjDespawnByTime;
    public ObjDespawnByTime ObjDespawnByTime => this._ObjDespawnByTime;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadVFXStun();
        this.LoadObjActionNipIndependantManager();
        this.LoadObjDespawnByTime();
    }

    protected virtual void LoadObjActionNipIndependantManager()
    {
        if (this._ObjActNipManager != null) return;

        this._ObjActNipManager = GetComponentInChildren<ObjActionNipIndependantManager>();
    }

    protected virtual void LoadVFXStun()
    {
        if (this._VFX_Stun != null) return;

        this._VFX_Stun = transform.Find("VFX_Stun");
        this._VFX_Stun.gameObject.SetActive(false);
    }

    protected virtual void LoadObjDespawnByTime()
    {
        if (this._ObjDespawnByTime != null) return;

        this._ObjDespawnByTime = GetComponentInChildren<ObjDespawnByTime>();
        this._ObjDespawnByTime.gameObject.SetActive(false);
    }

}


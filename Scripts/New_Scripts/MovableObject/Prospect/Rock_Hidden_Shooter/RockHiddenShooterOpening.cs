using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockHiddenShooterOpening : ObjActionHingeJoint
{
    [Header("RockHiddenShooterOpening")]
    [SerializeField] protected float _Distance_Open = 12f;
    [SerializeField] protected bool isActivated = false;
    public bool IsActivated => this.isActivated;

    [SerializeField] protected Transform _Sprite_Rock_Hidden;
    protected override void ResetValue()
    {
        base.ResetValue();

        this.isActivated = false;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadSpriteRockHidden();
    }

    protected virtual void LoadSpriteRockHidden()
    {
        if (this._Sprite_Rock_Hidden != null) return;

        this._Sprite_Rock_Hidden = transform.Find("Sprite_RockHidden_Disable");
    }

    protected virtual void FixedUpdate()
    {
        if (this.isActivated) return;

        if (PlayerCtrl.Instance == null) return;

        if (this.GetDistance() > this._Distance_Open) return;

        this.SpringTarget();

        this.isActivated = true;
        this._Sprite_Rock_Hidden.gameObject.SetActive(false);
    }

    protected virtual float GetDistance()
    {
        return this.transform.position.x - PlayerCtrl.Instance.transform.position.x;
    }
}

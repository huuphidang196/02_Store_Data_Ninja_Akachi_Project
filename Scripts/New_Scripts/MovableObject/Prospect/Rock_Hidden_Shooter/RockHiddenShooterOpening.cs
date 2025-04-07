using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockHiddenShooterOpening : ObjActionHingeJoint
{
    [Header("RockHiddenShooterOpening")]
    [SerializeField] protected bool isActivated = false;
    public bool IsActivated => this.isActivated;

    [SerializeField] protected Transform _Sprite_Rock_Hidden;
    [SerializeField] protected RockHiddenShooterCheckForward _RockHiddenShooterCheckForward;

    protected override void ResetValue()
    {
        this._TargetRot.Max *= this._ObjectCtrl.transform.localScale.x;
        this._LimitRot.Max *= this._ObjectCtrl.transform.localScale.x;

        base.ResetValue();

        this.isActivated = false;
    
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadSpriteRockHidden();
        this.LoadRockHiddenShooterCheckForward();
    }

    protected virtual void LoadSpriteRockHidden()
    {
        if (this._Sprite_Rock_Hidden != null) return;

        this._Sprite_Rock_Hidden = transform.Find("Sprite_RockHidden_Disable");
    }

    protected virtual void LoadRockHiddenShooterCheckForward()
    {
        if (this._RockHiddenShooterCheckForward != null) return;

        this._RockHiddenShooterCheckForward = GetComponentInChildren<RockHiddenShooterCheckForward>();
    }

    protected virtual void FixedUpdate()
    {
        if (this.isActivated) return;

        if (PlayerCtrl.Instance == null) return;

        if (!this._RockHiddenShooterCheckForward.ForwardObjRight) return;

        this.SpringTarget();

        this.isActivated = true;
        this._Sprite_Rock_Hidden.gameObject.SetActive(false);
        this._RockHiddenShooterCheckForward.gameObject.SetActive(false);
    }
}

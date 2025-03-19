using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockHiddenShooterCtrl : ObjectCtrl
{
    [SerializeField] protected RockHiddenShooterOpening _RockHiddenShooterOpening;
    public RockHiddenShooterOpening RockHiddenShooterOpening => this._RockHiddenShooterOpening;

    [SerializeField] protected RockHiddenShooterSoundManager _RockHiddenShooterSoundManager;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadRockHiddenShooterOpening();
        this.LoadRockHiddenShooterSouundManager();
    }
   
    protected virtual void LoadRockHiddenShooterOpening()
    {
        if (this._RockHiddenShooterOpening != null) return;

        this._RockHiddenShooterOpening = GetComponentInChildren<RockHiddenShooterOpening>();
    }
    protected virtual void LoadRockHiddenShooterSouundManager()
    {
        if (this._RockHiddenShooterSoundManager != null) return;

        this._RockHiddenShooterSoundManager = GetComponentInChildren<RockHiddenShooterSoundManager>();
    }

}

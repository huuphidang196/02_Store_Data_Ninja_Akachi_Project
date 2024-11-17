using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenVFXManager : WeaponCharacterVFXManager
{
    [SerializeField] protected Transform _Trail;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadTrailShuriken();
    }

    protected virtual void LoadTrailShuriken()
    {
        if (this._Trail != null) return;

        this._Trail = transform.Find("Trail_Shuriken");
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        this._Trail.gameObject.SetActive(true);
    }

    protected virtual void Update()
    {
        if (this._WeaponCharacterCtrl.WeaponCharacterImpact.TypeImpact == TypeImpact.NoImapct) return;

        this._Trail.gameObject.SetActive(false);
    }    
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCharacterVFXManager : WeaponCharacterAbstract
{
    [Header("WeaponCharacterVFXManager")]
    [SerializeField] protected GameObject _VFX_Ignite_Fire;

    [SerializeField] protected GameObject _VFX_Blood_Fly;

    [SerializeField] protected GameObject _VFX_Ground_Emit;

    [SerializeField] protected GameObject _VFX_WoodBox_Emit;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadVFXIgniteFire();
        this.LoadVFXBloodFly();
        this.LoadVFXGroundEmit();
        this.LoadVFXWoodBoxEmit();
    }

  
    protected virtual void LoadVFXIgniteFire()
    {
        if (this._VFX_Ignite_Fire != null) return;

        this._VFX_Ignite_Fire = transform.Find("VFX_Ignite_Fire").gameObject;
        this._VFX_Ignite_Fire.gameObject.SetActive(false);
    }

    protected virtual void LoadVFXBloodFly()
    {
        if (this._VFX_Blood_Fly != null) return;

        this._VFX_Blood_Fly = transform.Find("VFX_Blood_Fly").gameObject;
        this._VFX_Blood_Fly.gameObject.SetActive(false);
    }
    protected virtual void LoadVFXGroundEmit()
    {
        if (this._VFX_Ground_Emit != null) return;

        this._VFX_Ground_Emit = transform.Find("VFX_Ground_Emit").gameObject;
        this._VFX_Ground_Emit.gameObject.SetActive(false);
    }

    protected virtual void LoadVFXWoodBoxEmit()
    {
        if (this._VFX_WoodBox_Emit != null) return;

        this._VFX_WoodBox_Emit = transform.Find("VFX_WoodBox_Emit").gameObject;
        this._VFX_WoodBox_Emit.gameObject.SetActive(false);
    }


    protected virtual void FixedUpdate()
    {
        //Pause Game
        this.UpdateVFXIgniteFire();

        this.UpdateVFXBloodEnemyEmit();

        this.UpdateVFXBGroundEmit();

        this.UpdateVFXWoodBoxEmit();
    }

    protected virtual void UpdateVFXIgniteFire()
    {
        if (this._VFX_Ignite_Fire.activeInHierarchy == this._WeaponCharacterCtrl.WeaponCharacterImpact.IsImpacted_Igniting_Fire) return;

        this._VFX_Ignite_Fire.SetActive(this._WeaponCharacterCtrl.WeaponCharacterImpact.IsImpacted_Igniting_Fire);

    }

    protected virtual void UpdateVFXBloodEnemyEmit()
    {
        if (this._VFX_Blood_Fly.activeInHierarchy == this._WeaponCharacterCtrl.WeaponCharacterImpact.IsImpacted_Emit_Blood) return;

        this._VFX_Blood_Fly.SetActive(this._WeaponCharacterCtrl.WeaponCharacterImpact.IsImpacted_Emit_Blood);

    }

    protected virtual void UpdateVFXBGroundEmit()
    {
        if (this._VFX_Ground_Emit.activeInHierarchy == this._WeaponCharacterCtrl.WeaponCharacterImpact.IsImpacted_Emit_Ground) return;

        this._VFX_Ground_Emit.SetActive(this._WeaponCharacterCtrl.WeaponCharacterImpact.IsImpacted_Emit_Ground);

    }

    protected virtual void UpdateVFXWoodBoxEmit()
    {
        if (this._VFX_WoodBox_Emit.activeInHierarchy == this._WeaponCharacterCtrl.WeaponCharacterImpact.IsImpacted_Emit_WoodBox) return;

        this._VFX_WoodBox_Emit.SetActive(this._WeaponCharacterCtrl.WeaponCharacterImpact.IsImpacted_Emit_WoodBox);

    }
}

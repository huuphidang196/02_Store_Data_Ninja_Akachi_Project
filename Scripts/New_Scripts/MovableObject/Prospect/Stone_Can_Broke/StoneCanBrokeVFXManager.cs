using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneCanBrokeVFXManager : StoneCanBrokeAbstract
{
    [SerializeField] protected GameObject _VFX_Stone_Broke;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadVFXStoneBroke();
    }

    protected virtual void LoadVFXStoneBroke()
    {
        if (this._VFX_Stone_Broke != null) return;

        this._VFX_Stone_Broke = transform.Find("VFX_Stone_Broke").gameObject;
        this._VFX_Stone_Broke.gameObject.SetActive(false);
    }
    protected virtual void Update()
    {
        this.UpdateVFXIgniteFire();
    }

    protected virtual void UpdateVFXIgniteFire()
    {
        if (this._VFX_Stone_Broke.activeInHierarchy == this._StoneCanBrokeCtrl.StoneCanBrokeDamReceiver.ObjIsDead) return;

        this._VFX_Stone_Broke.SetActive(this._StoneCanBrokeCtrl.StoneCanBrokeDamReceiver.ObjIsDead);

    }
}

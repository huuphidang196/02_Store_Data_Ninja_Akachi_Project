using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnTowerCtrl : ObjectCtrl
{
    [SerializeField] protected LightRespawnTower _LightRespawnTower;
    public LightRespawnTower LightRespawnTower => this._LightRespawnTower;


    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadLightRespawnTower();
    }

    protected virtual void LoadLightRespawnTower()
    {
        if (this._LightRespawnTower != null) return;

        this._LightRespawnTower = GetComponentInChildren<LightRespawnTower>();
    }

}

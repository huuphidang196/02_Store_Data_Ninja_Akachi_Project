using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCheckForward : EnemyCheckForward
{
    protected BossCheckContactEnviroment _BossCheckContactEnviroment => this.CharacterCheckContactEnviroment as BossCheckContactEnviroment;
    protected override void LoadLayerMaskForward()
    {
        if (this._ObjForwardLayer.Length > 0) return;

        this._ObjForwardLayer = new string[3];
        this._ObjForwardLayer[0] = "Player";
        this._ObjForwardLayer[1] = "Ground";
        this._ObjForwardLayer[2] = "PlayerHiddenMode";
    }

    protected override bool CheckAllOtherConditionsToContinue()
    {
        return !this._BossCheckContactEnviroment.BossCtrl.InputManagerBoss.IsCoolAttack;
    }
    protected override void ScanTargetOnFOV()
    {
        if (this._TargetFollow == null) this._TargetFollow = this.GetTargetFollowByCondition();

        base.ScanTargetOnFOV();
    }

    protected virtual Transform GetTargetFollowByCondition()
    {
        if (this._BossCheckContactEnviroment.BossCtrl.InputManagerBoss.IsCoolAttack || PlayerCtrl.Instance.gameObject.layer != LayerMask.NameToLayer(this._ObjForwardLayer[0])
               || !this.CheckForwardObjectIsRight()) return null;

        return PlayerCtrl.Instance.transform;
    }
}

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

    protected override void SetBoolAfterImpactOrNotAllow()
    {
        base.SetBoolAfterImpactOrNotAllow();
        this._ForwardObjRight = false;
    }
    protected override bool CheckAllOtherConditionsToContinue()
    {
       return !this._BossCheckContactEnviroment.BossCtrl.InputManagerBoss.IsCoolAttack;
    }
    protected override void ScanTargetOnFOV()
    {
        if (!this._BossCheckContactEnviroment.BossCtrl.InputManagerBoss.IsCoolAttack) this._TargetFollow = PlayerCtrl.Instance.transform;

        base.ScanTargetOnFOV();
    }

}

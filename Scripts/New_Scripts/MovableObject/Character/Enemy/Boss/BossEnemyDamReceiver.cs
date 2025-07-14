using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyDamReceiver : EnemyDamReceiver
{
    protected BossCtrl _BossCtrl => this.EnemyCtrl as BossCtrl;
    public override void DeductHP(float damage)
    {
        if (this.isDead || !this._BossCtrl.InputManagerBoss.IsBeginFighter || !this._BossCtrl.InputManagerBoss.IsBeginIntroduce 
            || this._BossCtrl.BossAnimation.IsFlowDarkAttack || this._BossCtrl.BossEnemyMovement.IsShadowing) return;

        base.DeductHP(damage);
    }

    protected override void InActiveEnemy()
    {
        //End Game
        Debug.Log("End Game");
    }

    public virtual void SetLayerIgnoreImpact(bool isIgnored)
    {
        int layer = isIgnored ? LayerMask.NameToLayer("Default") : LayerMask.NameToLayer("Enemy");
        this._BossCtrl.gameObject.layer = layer;
        this.gameObject.layer = layer;
    }    
}

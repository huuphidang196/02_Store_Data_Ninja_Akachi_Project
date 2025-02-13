using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackAlways : EnemyAttackByImpact
{
    protected override void Update()
    {
        base.Update();

        if (this.isSlash == this._EmemyImpactTriggerSendDam.gameObject.activeInHierarchy) return;

        this.EnemyAttackPlayer();
    }

    protected virtual void EnemyAttackPlayer()
    {
        this.ChangeLayerWeaponToAttacKPlayer(this.isSlash);
        this._EmemyImpactTriggerSendDam.gameObject.SetActive(this.isSlash);
    }
}

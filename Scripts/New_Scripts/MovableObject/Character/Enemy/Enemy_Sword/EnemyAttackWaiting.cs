using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackWaiting : EnemyAttackAlways
{
    protected override void EnemyAttackPlayer()
    {
        Invoke(nameof(this.EnemyAttackPlayerAfterWaiting), 0.2f);
    }
    protected virtual void EnemyAttackPlayerAfterWaiting()
    {
        this.ChangeLayerWeaponToAttacKPlayer(this.isSlash);
        this._EmemyImpactTriggerSendDam.gameObject.SetActive(this.isSlash);
    }
}

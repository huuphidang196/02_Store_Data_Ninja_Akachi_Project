using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCheckForward : EnemyCheckForward
{
    protected BossCheckContactEnviroment _BossCheckContactEnviroment => this.CharacterCheckContactEnviroment as BossCheckContactEnviroment;
    protected override void ProcessFixedUpdateEvent()
    {
        if (this._BossCheckContactEnviroment.BossCtrl.InputManagerBoss.IsCoolAttack)
        {
            this._ForwardObjRight = false;
            base.SetBoolAfterImpactOrNotAllow();
            return;
        }    

        base.ProcessFixedUpdateEvent();
    }


    protected override void SetBoolAfterImpactOrNotAllow()
    {
        this.isChangedDirForward = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooterCheckForward : EnemyCheckForward
{
    protected override bool CheckConditionAllowFlip()
    {
        return !this.CheckForwardIsHaveRightObjectLayerCustom(this._ObjForwardLayer[1]);
    }

}

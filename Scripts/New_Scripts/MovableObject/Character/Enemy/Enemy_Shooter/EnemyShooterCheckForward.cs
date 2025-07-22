using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooterCheckForward : EnemyCheckForward
{
    protected override bool CheckForwardObjectIsRight()
    {
        return !this.CheckForwardIsHaveRightObjectLayerCustom(this._ObjForwardLayer[1]);
    }

}

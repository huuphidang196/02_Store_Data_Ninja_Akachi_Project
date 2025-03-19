using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooterHiddenCheckForward : EnemyShooterCheckForward
{
    protected override void ResetValue()
    {
        this.LoadLayerMaskForward();
    }

}

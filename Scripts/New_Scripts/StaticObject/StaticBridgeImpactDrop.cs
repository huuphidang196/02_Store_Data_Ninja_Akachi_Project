using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticBridgeImpactDrop : ObjImpactTargetPlayerAndHidenModePlayer
{
    public StaticBridgeCtrl StaticBridgeCtrl => this._ObjectCtrl as StaticBridgeCtrl;

    protected override void ProcessAfterObjectImpacted()
    {
        this.StaticBridgeCtrl.StaticBridgeProspectDropping.Dropped();

    }
}

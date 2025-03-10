using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearTrapImpact : ObjImpactTargetPlayerAndHidenModePlayer
{
    public JawBearTrapCtrl JawBearTrapCtrl => this._ObjectCtrl as JawBearTrapCtrl;

    protected override void EventImpactEnter2D(GameObject col)
    {
        //base.EventImpactEnter2D(col);

        this.JawBearTrapCtrl.ObjActionNipIndependantManager.CloseTrap();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearTrapImpact : ObjImpactTargetPlayerAndHidenModePlayer
{
    public JawBearTrapCtrl JawBearTrapCtrl => this._ObjectCtrl as JawBearTrapCtrl;

    protected override void ProcessAfterObjectImpacted()
    {
        this.JawBearTrapCtrl.ObjActionNipIndependantManager.CloseTrap();

    }

    protected override bool CheckObjectImapactAllowedImpact()
    {
        if (this.CheckParentObjectImpactWithAnyLayer("WeaponPlayer")) return false;

        return base.CheckObjectImapactAllowedImpact();
    }
}

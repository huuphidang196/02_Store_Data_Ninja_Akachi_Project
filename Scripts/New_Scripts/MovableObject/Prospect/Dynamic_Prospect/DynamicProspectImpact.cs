using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicProspectImpact : MovableObjImpactToChangeDir
{
    public DynamicMovementCtrl DynamicMovementCtrl => this._ObjectCtrl as DynamicMovementCtrl;

    protected override void ProcessAfterObjectImpacted()
    {
        this.DynamicMovementCtrl.ObjKinematicMovement.ChangeDir();

    }
}

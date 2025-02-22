using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicMovementCtrl : MovableObjCtrl
{
    public MovableObjKinematicMovement MovableObjKinematicMovement => this._MovableObj_Movement as MovableObjKinematicMovement;

    protected override string GetNameFolderTypeObject()
    {
        return "Prospect";
    }
}

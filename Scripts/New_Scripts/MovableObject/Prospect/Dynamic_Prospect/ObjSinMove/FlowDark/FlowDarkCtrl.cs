using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowDarkCtrl : DynamicMovementCtrl
{
    public FlowDarkMovement FlowDarkMovement => this._MovableObj_Movement as FlowDarkMovement;

    protected override string GetNameFolderTypeObjectUsing()
    {
        return "DynamicProspect/";
    }
}

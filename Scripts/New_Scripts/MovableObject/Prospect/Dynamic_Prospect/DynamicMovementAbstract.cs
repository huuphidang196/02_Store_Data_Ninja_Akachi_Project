using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicMovementAbstract : MovableObjAbstract
{
    public DynamicMovementCtrl DynamicMovementCtrl => this._MovableObjCtrl as DynamicMovementCtrl;
}

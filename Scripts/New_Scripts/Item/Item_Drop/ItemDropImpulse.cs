using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ItemDropImpulse : ObjDropImpluse
{
    [SerializeField] protected ItemDropCtrl _ItemDropCtrl => this._ObjectCtrl as ItemDropCtrl;

  
}

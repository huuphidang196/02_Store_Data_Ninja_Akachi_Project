using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjDisableParentByDistaneCompareTarget : ObjDisableOrEnableFollowTargetManager
{
    protected override void ResetValue()
    {
        base.ResetValue();

        this._Obj_Action = transform.parent;
    }

}

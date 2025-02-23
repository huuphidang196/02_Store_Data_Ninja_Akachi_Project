using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjDisableOrEnableFollowTargetManager : EventScenePlayAutoOnByDistancePlayer
{
    [SerializeField] protected Transform _Obj_Action;

    protected override void Update()
    {
        if (this._Obj_Action == null) return;

        if (!this.activated && !this.AllowActive()) return;

        this.activated = this.AllowActive();

        this.ConductActionEvents();   
    }

    protected override bool AllowActive()
    {
        return Mathf.Abs(this.GetDistance()) < activationDistance;
    }

    protected override void ConductActionEvents()
    {
        this._Obj_Action.gameObject.SetActive(this.activated);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowDarkDespawn : ObjDisableParentByDistaneCompareTarget
{
    [SerializeField] protected FlowDarkCtrl _FlowDarkCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadFlowDarkCtrl();
    }

    protected virtual void LoadFlowDarkCtrl()
    {
        if (this._FlowDarkCtrl != null) return;

        this._FlowDarkCtrl = transform.parent.GetComponent<FlowDarkCtrl>();
    }

    protected override void Start()
    {
        base.Start();

        this.activationDistance = BossCtrl.Instance.InputManagerBoss.Distance_MoveFlow_Axis_X;
    }

    protected override float GetDistance()
    {
        return this._FlowDarkCtrl.FlowDarkMovement.GetDistanceXMoved();
    }

    protected override bool AllowActive()
    {
        return !(Mathf.Abs(this.GetDistance()) >= activationDistance && !PlayerCtrl.Instance.ObjDamageReceiver.ObjIsDead);
    }

}

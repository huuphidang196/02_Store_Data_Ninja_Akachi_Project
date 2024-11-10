using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneCanBrokeCtrl : ObjectCtrl
{
    public StoneCanBrokeDamReceiver StoneCanBrokeDamReceiver => this._ObjDamageReceiver as StoneCanBrokeDamReceiver;

    [SerializeField] protected StoneCanBrokeModel _StoneCanBrokeModel;
    public StoneCanBrokeModel StoneCanBrokeModel => this._StoneCanBrokeModel;
    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadStoneCanBrokeModel();
    }

    protected virtual void LoadStoneCanBrokeModel()
    {
        if (this._StoneCanBrokeModel != null) return;

        this._StoneCanBrokeModel = GetComponentInChildren<StoneCanBrokeModel>();
    }

}

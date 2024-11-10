using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneCanBrokeAbstract : SurMonoBehaviour
{
    [SerializeField] protected StoneCanBrokeCtrl _StoneCanBrokeCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadStoneCanBrokeCtrl();
    }

    protected virtual void LoadStoneCanBrokeCtrl()
    {
        if (this._StoneCanBrokeCtrl != null) return;

        this._StoneCanBrokeCtrl = transform.parent.GetComponent<StoneCanBrokeCtrl>();
    }
}

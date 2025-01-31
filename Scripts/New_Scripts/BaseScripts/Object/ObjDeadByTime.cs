using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjDeadByTime : ObjectAbstract
{
    [SerializeField] protected float _Time_Delay = 2f;
    [SerializeField] protected float _Timer = 0f;

    protected override void OnEnable()
    {
        base.OnEnable();

        this.Reborn();
    }

    protected virtual void Reborn()
    {
        this._Timer = 0f;
    }

    protected virtual void Update()
    {
        this._Timer += Time.deltaTime;
        if (this._Timer <= this._Time_Delay) return;

        this.ProcessDeadEvent();
    }

    protected virtual void ProcessDeadEvent()
    {
      
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjDespawnByTime : ObjDespawn
{

    [SerializeField] protected float _Delay = 2f;
    [SerializeField] protected float _Timer = 0;

    protected override void OnEnable()
    {
        base.OnEnable();
        this.ResetTimer();
    }
    protected virtual void ResetTimer()
    {
        this._Timer = 0;
    }
    protected override bool CanDespawn()
    {
        this._Timer += Time.fixedDeltaTime;
        if (this._Timer > this._Delay) return true;

        return false;
    }
}

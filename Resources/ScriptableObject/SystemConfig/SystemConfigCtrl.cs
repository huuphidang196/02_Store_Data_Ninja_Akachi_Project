using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemConfigCtrl : ScriptableObject
{
    [SerializeField] protected SystemConfig _SystemConfig;
    public SystemConfig SystemConfig => this._SystemConfig;

    protected virtual void Reset()
    {
        this.LoadComponents();
    }

    protected virtual void LoadComponents()
    {
        if (this._SystemConfig != null) return;

        this._SystemConfig = Resources.Load<SystemConfig>("ScriptableObject/SystemConfig/SystemConfig");
    }
}

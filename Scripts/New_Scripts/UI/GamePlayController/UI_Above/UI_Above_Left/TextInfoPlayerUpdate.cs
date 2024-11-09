using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextInfoPlayerUpdate : BaseText
{
    [SerializeField] protected UIAboveInfoPlayerManager _UIAboveInfoPlayerManager;
    public UIAboveInfoPlayerManager UIAboveInfoPlayerManager => this._UIAboveInfoPlayerManager;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadUIAboveInfoPlayerManager();
    }

    protected virtual void LoadUIAboveInfoPlayerManager()
    {
        if (this._UIAboveInfoPlayerManager != null) return;

        this._UIAboveInfoPlayerManager = transform.parent.GetComponent<UIAboveInfoPlayerManager>();
    }

    protected override void FixedUpdate()
    {
        this.UpdateContentByGetDataSystemConfig();
        base.FixedUpdate();
    }

    protected virtual void UpdateContentByGetDataSystemConfig()
    {
        string dataCongfig = this.GetDataValue();
        this.SetContent(dataCongfig);
    }

    protected virtual string GetDataValue()
    {
        return "";
    }
}

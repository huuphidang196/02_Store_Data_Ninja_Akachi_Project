using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseUICtrl : SurMonoBehaviour
{
    [SerializeField] protected BaseText _BaseText;
    public BaseText BaseText => this._BaseText;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadBaseText();
    }

    protected virtual void LoadBaseText()
    {
        if (this._BaseText != null) return;

        this._BaseText = GetComponentInChildren<BaseText>();
    }
}

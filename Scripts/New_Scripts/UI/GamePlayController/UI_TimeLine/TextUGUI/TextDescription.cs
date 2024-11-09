using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextDescription : BaseText
{
    [SerializeField] protected TextUICtrl _TextUICtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadTextFlyingCtrl();
    }

    protected virtual void LoadTextFlyingCtrl()
    {
        if (this._TextUICtrl != null) return;

        this._TextUICtrl = GetComponentInParent<TextUICtrl>();
    }
}

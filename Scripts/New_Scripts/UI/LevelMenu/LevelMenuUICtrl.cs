using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMenuUICtrl : SurMonoBehaviour
{
    [SerializeField] protected UIBelowCtrl _UIBelowCtrl;
    public UIBelowCtrl UIBelowCtrl => this._UIBelowCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadUIBelowCtrl();
    }

    protected virtual void LoadUIBelowCtrl()
    {
        if (this._UIBelowCtrl != null) return;

        this._UIBelowCtrl = GetComponentInChildren<UIBelowCtrl>();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMenuUIAbstract : SurMonoBehaviour
{
    [SerializeField] protected LevelMenuUICtrl _LevelMenuUICtrl;
    public LevelMenuUICtrl LevelMenuUICtrl => this._LevelMenuUICtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadLevelMenuUICtrl();
    }

    protected virtual void LoadLevelMenuUICtrl()
    {
        if (this._LevelMenuUICtrl != null) return;

        this._LevelMenuUICtrl = GetComponentInParent<LevelMenuUICtrl>();
    }
}

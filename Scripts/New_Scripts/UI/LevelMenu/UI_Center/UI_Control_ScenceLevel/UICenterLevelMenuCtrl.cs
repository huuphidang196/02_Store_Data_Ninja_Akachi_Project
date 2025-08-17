using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICenterLevelMenuCtrl : SurMonoBehaviour
{
    [SerializeField] protected UICenterControlSceneLevel _UICenterControlSceneLevel;
    public UICenterControlSceneLevel UICenterControlSceneLevel => this._UICenterControlSceneLevel;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadUICenterControlSceneLevel();
    }

    protected virtual void LoadUICenterControlSceneLevel()
    {
        if (this._UICenterControlSceneLevel != null) return;

        this._UICenterControlSceneLevel = GetComponentInChildren<UICenterControlSceneLevel>();
    }
}

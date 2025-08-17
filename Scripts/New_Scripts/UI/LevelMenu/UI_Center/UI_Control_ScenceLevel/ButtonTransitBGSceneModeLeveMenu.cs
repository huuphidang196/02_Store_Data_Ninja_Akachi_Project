using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTransitBGSceneModeLeveMenu : BaseButton
{
    [SerializeField] protected bool isNext;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.SetIsNext();
    }

    protected virtual void SetIsNext()
    {
        this.isNext = transform.name.Contains("Next");
    }

    protected override void OnClick()
    {
        base.OnClick();

        UICenterManager.Instance.ProcessTransitImageBGRepresentLevelMode(this.isNext);
    }
}

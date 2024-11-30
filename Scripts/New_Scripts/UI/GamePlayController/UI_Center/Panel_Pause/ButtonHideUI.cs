using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHideUI : BaseButton
{
    protected override void OnClick()
    {
        base.OnClick();

        GamePlayUIManager.Instance.IsHidenUIScenePlay();

        GamePlayUIManager.Instance.TogglePanelPause();
    }
}

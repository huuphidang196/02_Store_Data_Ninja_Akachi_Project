using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAdsSettingMainMenu : BaseButton
{
    protected override void OnClick()
    {
        base.OnClick();

        UICenterMainMenuCtrl.Instance.UICenterMainMenuManager.ToggelPanelADSSettingMenu();
    }
}

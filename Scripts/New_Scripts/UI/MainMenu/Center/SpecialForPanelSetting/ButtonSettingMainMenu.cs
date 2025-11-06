using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSettingMainMenu : BaseButton
{
    protected override void OnClick()
    {
        base.OnClick();

        UICenterMainMenuCtrl.Instance.UICenterMainMenuManager.ToggelPanelSettingMenu();
    }
}

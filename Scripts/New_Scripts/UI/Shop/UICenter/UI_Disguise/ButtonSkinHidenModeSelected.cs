using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSkinHidenModeSelected : BaseButton
{
    protected override void OnClick()
    {
        base.OnClick();

        UICenterShopManager.Instance.UICenterShopCtrl.UIShopCenterDisguiseManager.
            ChangeOtherSkinHiden(this.transform.parent.GetSiblingIndex());
    }
}

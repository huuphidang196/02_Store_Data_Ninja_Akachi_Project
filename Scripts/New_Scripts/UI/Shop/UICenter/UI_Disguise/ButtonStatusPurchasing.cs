using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonStatusPurchasing : BaseButton
{
    protected override void OnClick()
    {
        base.OnClick();

        ShopMenuController.Instance.EquipOrBuyingSkinHidenMode();
    }
}

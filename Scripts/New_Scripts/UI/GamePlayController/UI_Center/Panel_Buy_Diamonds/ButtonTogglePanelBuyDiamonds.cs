using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTogglePanelBuyDiamonds : BaseButton
{
    protected override void OnClick()
    {
        base.OnClick();

        GamePlayUIManager.Instance.TogglePanelBuyDiamonds();
    }
}

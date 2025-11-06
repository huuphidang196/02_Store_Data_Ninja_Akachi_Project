using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonChangeVolumnMuisc : BaseButton
{
    protected override void OnClick()
    {
        base.OnClick();

        MainMenuController.Instance.ChangeStatusOnOffMusic();
    }
}

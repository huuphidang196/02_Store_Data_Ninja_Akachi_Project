using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMusicChanging : BaseButton
{
    protected override void OnClick()
    {
        base.OnClick();

        GamePlayUIManager.Instance.ChangeStatusOnOffMusic();
    }
}

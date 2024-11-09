using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPause : BaseButton
{
    protected override void OnClick()
    {
        base.OnClick();
        GamePlayUIManager.Instance.TogglePanelPause();

        //set false hiden button at the same time
        GamePlayUIManager.Instance.TurnOnUIScenPlay();

        //Pause Game Controller
        GameController.Instance.PauseGamePlay();
    }
}

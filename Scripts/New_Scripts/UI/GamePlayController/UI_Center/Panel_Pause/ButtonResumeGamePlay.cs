using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonResumeGamePlay : BaseButton
{
    protected override void OnClick()
    {
        base.OnClick();

        GamePlayUIManager.Instance.TogglePanelPause();
        //Pause Game Controller
        GameController.Instance.ContinueGamePlay();
    }
}

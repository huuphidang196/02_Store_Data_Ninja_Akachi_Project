using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonNextStage : BaseButton
{
    protected override void OnClick()
    {
        base.OnClick();

        LevelMenuController.Instance.StartLoadingSceneByOrderScene(GameController.Instance.SystemConfig.Current_Level + 1);
    }
}

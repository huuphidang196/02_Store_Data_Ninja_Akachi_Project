using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonNextStage : BaseButton
{
    protected override void OnClick()
    {
        base.OnClick();

        GamePlayController.Instance.LoadNextStageAndConductAllActionSet();

        // Previous Action incresed current level by 1
        GamePlayController.Instance.StartLoadingSceneByOrderScene(GamePlayController.Instance.SystemConfig.Current_Level);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonRestartScenePlay : BaseButton
{
    protected override void OnClick()
    {
        base.OnClick();

        SaveManager.Instance.SaveGame();
        GamePlayController.Instance.StartLoadingSceneByOrderScene(GamePlayController.Instance.SystemConfig.Current_Level);
    }
}

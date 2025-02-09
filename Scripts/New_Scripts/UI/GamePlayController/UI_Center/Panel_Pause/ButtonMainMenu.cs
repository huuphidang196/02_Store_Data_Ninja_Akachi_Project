using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMainMenu : BaseButton
{
    protected override void OnClick()
    {
        base.OnClick();

        SaveManager.Instance.SaveGame();
        GamePlayController.Instance.StartLoadingSceneByNameScene("LevelMenu");
    }
}

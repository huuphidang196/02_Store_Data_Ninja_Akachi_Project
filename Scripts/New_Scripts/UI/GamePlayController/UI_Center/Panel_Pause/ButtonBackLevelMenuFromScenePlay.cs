using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBackLevelMenuFromScenePlay : BaseButton
{
    protected override void OnClick()
    {
        base.OnClick();
        SaveManager.Instance.SaveGame();
        GamePlayController.Instance.StartLoadingSceneByNameSceneAfterWatchAds("LevelMenu");
    }

}

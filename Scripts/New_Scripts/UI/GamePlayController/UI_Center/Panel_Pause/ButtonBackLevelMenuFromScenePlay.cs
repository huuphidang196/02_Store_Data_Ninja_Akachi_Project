using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBackLevelMenuFromScenePlay : BaseButton
{
    protected override void OnClick()
    {
        base.OnClick();
        SoundManagerOverall.Instance.BG_Sound_Scene_Play_Mode.IncreseOrderSound();
        GamePlayController.Instance.StartLoadingSceneByNameScene("LevelMenu");
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPlay : BaseButton
{
    protected override void OnClick()
    {
        base.OnClick();

        string nameScene = LevelMenuController.Instance.GetNameSceneCurrent();

        SceneManager.LoadScene(nameScene);
    }
}

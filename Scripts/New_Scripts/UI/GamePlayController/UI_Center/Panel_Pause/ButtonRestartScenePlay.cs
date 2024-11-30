using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonRestartScenePlay : BaseButton
{
    protected override void OnClick()
    {
        base.OnClick();

        GameController.Instance.ContinueGamePlay();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

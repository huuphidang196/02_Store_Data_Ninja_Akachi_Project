using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonBackMainMenu : BaseButton
{
    protected override void OnClick()
    {
        base.OnClick();

        if (SaveManager.Instance != null) SaveManager.Instance.SaveGame();

        Invoke(nameof(this.LoadMainMenu), 1f);
    }

    protected virtual void LoadMainMenu()
    {
        if (!SystemController.Sys_Instance.SystemConfig.isFinishedStory)
        {
            SceneManager.LoadScene("Introduce");
            return;
        }    

        SceneManager.LoadScene("MainMenu");
    }
}




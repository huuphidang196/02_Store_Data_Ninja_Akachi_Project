using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonBackMainMenu : BaseButton
{
    protected override void OnClick()
    {
        base.OnClick();

        SaveManager.Instance.SaveGame();

        Invoke(nameof(this.LoadMainMenu), 0.5f);
    }

    protected virtual void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }    
}




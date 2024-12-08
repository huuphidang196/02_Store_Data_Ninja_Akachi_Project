using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonBackMainMenu : BaseButton
{
    protected override void OnClick()
    {
        base.OnClick();

        SceneManager.LoadScene("MainMenu");

    }
}




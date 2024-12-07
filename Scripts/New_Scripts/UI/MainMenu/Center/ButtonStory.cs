using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonStory : BaseButton
{
    protected override void OnClick()
    {
        SceneManager.LoadScene("LevelMenu");
    }
}

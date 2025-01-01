using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonLoadShopScene : BaseButton
{
    protected override void OnClick()
    {
        base.OnClick();

        SceneManager.LoadScene("ShopScene");
    }
}

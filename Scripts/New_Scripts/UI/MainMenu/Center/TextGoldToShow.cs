using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextGoldToShow : TextShowGetValue
{
    protected override string GetValueToShow()
    {
        return MainMenuController.Instance.SystemConfig.Total_Golds + "";
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextDiamondsToShow : TextShowOnlyOnceSet
{
    protected override string GetValueToShow()
    {
        return MainMenuController.Instance.SystemConfig.Total_Diamonds.ToString();
    }
}

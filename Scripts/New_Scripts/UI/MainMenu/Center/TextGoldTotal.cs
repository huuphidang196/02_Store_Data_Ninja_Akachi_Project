using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextGoldTotal : TextShowOnceStart
{
    protected override string GetValueToShow()
    {
        return MainMenuController.Instance.SystemConfig.Total_Golds.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextGoldTotal : TextMoneyTotalToShow
{
    protected override string GetValueMoneyToShow()
    {
        return MainMenuController.Instance.SystemConfig.Total_Golds.ToString();
    }
}

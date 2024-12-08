using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextDiamondsToShow : TextMoneyTotalToShow
{
    protected override string GetValueMoneyToShow()
    {
        return MainMenuController.Instance.SystemConfig.Total_Diamonds.ToString();
    }
}

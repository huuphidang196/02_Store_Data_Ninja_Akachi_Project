using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextLevelCurrent : TextShowOnlyOnceSet
{
    protected override string GetValueToShow()
    {
        return GamePlayController.Instance.SystemConfig.Current_Level + "";
    }
}

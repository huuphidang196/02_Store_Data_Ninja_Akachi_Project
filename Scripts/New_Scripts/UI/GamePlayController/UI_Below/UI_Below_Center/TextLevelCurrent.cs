using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextLevelCurrent : TextShowOnlyOnceSet
{
    protected override string GetValueToShow()
    {
        return GameController.Instance.SystemConfig.Current_Level + "";
    }
}

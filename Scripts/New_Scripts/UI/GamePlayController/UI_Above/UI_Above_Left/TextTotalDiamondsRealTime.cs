using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTotalDiamondsRealTime : TextInfoPlayerUpdate
{
    protected override string GetDataValue()
    {
        float totalDiamonds = SystemController.Sys_Instance.SystemConfig.Total_Diamonds;

        return totalDiamonds.ToString();
    }

}

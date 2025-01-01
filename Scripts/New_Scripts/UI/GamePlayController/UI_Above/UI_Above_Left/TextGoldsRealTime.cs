using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextGoldsRealTime : TextInfoPlayerUpdate
{
    protected override string GetDataValue()
    {
        float totalGold = SystemController.Sys_Instance.SystemConfig.Total_Golds;
        return totalGold.ToString();
    }

    

}

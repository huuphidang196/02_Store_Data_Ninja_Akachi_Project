using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextGoldsRealTime : TextInfoPlayerUpdate
{
    protected override string GetDataValue()
    {
        float totalGold = this._UIAboveInfoPlayerManager.GamePlayUIOverall.GamePlayConfigUIOverall.SystemConfig.Total_Golds;
        return totalGold.ToString();
    }

    

}

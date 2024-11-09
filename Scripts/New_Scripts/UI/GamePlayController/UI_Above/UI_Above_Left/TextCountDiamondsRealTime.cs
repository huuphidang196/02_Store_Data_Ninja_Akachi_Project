using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextCountDiamondsRealTime : TextInfoPlayerUpdate
{
    protected override string GetDataValue()
    {
        if (this._UIAboveInfoPlayerManager.GamePlayUIOverall.GamePlayConfigUIOverall.SystemConfig == null) return "null";
        float totalDiamonds = this._UIAboveInfoPlayerManager.GamePlayUIOverall.GamePlayConfigUIOverall.SystemConfig.Total_Diamonds;
        totalDiamonds = 5;
        return totalDiamonds.ToString();
    }

}

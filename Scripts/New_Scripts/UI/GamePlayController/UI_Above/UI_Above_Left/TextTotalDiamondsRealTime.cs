using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTotalDiamondsRealTime : TextInfoPlayerUpdate
{
    protected override string GetDataValue()
    {
        float totalDiamonds = this._UIAboveInfoPlayerManager.GamePlayUIOverall.GamePlayConfigUIOverall.SystemConfig.Total_Diamonds;

        return totalDiamonds.ToString();
    }

}

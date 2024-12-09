using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextStarMissionAcquired : TextShowOnceStart
{
    protected override string GetValueToShow()
    {
        return LevelMenuController.Instance.SystemConfig.GetAllStarMissionAcquired() + "/45";
    }
}

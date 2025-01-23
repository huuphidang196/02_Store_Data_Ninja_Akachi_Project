using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextStarMissionAcquired : TextShowOnlyOnceSet
{
    protected override string GetValueToShow()
    {
        return (LevelMenuController.Instance.SystemConfig.GetCountAllStarMissionAcquired() + "/45");
    }
}

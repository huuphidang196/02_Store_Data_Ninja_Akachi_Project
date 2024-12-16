using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextStarMissionAchieved : TextShowGetValue
{
    protected override void Start()
    {
        base.Start();
        this.SetTextToShow();
    }
    protected override void FixedUpdate()
    {
       
    }
    protected override string GetValueToShow()
    {
        return LevelMenuController.Instance.SystemConfig.GetAllStarMissionAcquired() + "/45";
    }
}

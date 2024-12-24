using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GroupStarAcquired : SurMonoBehaviour
{
    #region LoadComponents
    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadGroupStars();
    }

    protected virtual void LoadGroupStars()
    {
        foreach (Transform item in this.transform)
        {
            item.GetComponent<Image>().color = Color.black;
        }
    }

    #endregion

    protected override void Start()
    {
        base.Start();

        this.SetElementOfButtonBegin();
    }

    protected virtual void SetElementOfButtonBegin()
    {
        int current_Level = GameController.Instance.SystemConfig.Current_Level;
        //Set Active true star
        int count = GameController.Instance.SystemConfig.GetStarMissionByLevel(current_Level) != null ?
            GameController.Instance.SystemConfig.GetStarMissionByLevel(current_Level).Count_Star_Acquired : 0;
        for (int i = 0; i < count; i++)
        {
            this.transform.GetChild(i).GetComponent<Image>().color = Color.white;
        }

    }

}

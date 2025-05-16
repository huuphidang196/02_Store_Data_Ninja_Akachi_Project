using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public enum GuidanceButtonFirstTime
{
    Completed_Guidance = 0,

    Guidance_Plot_Summary = 1,
    Guidance_Jump_Button = 2,
    Guidance_Throw_Shuriken_Button = 3,
    Guidance_Dashing_Button = 4,
    Guidance_Broke_Hidden_Stone = 5,
    Guidance_Hidden_Button = 6,
    Guidance_Star_Mission = 7,
}

[Serializable]
public class GuidanceButtonActive
{
    public GuidanceButtonFirstTime TypeGuidanceButton;
    public bool ActiveButton;
}

public class GuidanceFirstTimePlaying : Singleton<GuidanceFirstTimePlaying>
{
    [SerializeField] protected GuidanceButtonFirstTime _GuidanceButtonFirstTime = GuidanceButtonFirstTime.Completed_Guidance;
    [SerializeField] protected float _Radius_Active_Guidance = 5;
    [SerializeField] protected List<GuidanceButtonActive> _List_GuidanceButtonActive;
    [SerializeField] protected int _Order_Guidance_Current_Check = 0;

    protected override void Reset()
    {
        base.Reset();

        this.AddValueForList();
        this.SetActiveFalseAllObjectChild();
    }

    protected virtual void AddValueForList()
    {
        if (this._List_GuidanceButtonActive.Count > 0) return;

        foreach (GuidanceButtonFirstTime type in System.Enum.GetValues(typeof(GuidanceButtonFirstTime)))
        {
            if (type == GuidanceButtonFirstTime.Completed_Guidance)
                continue;

            GuidanceButtonActive newButton = new GuidanceButtonActive
            {
                TypeGuidanceButton = type,
                ActiveButton = false
            };

            this._List_GuidanceButtonActive.Add(newButton);
        }
    }
    protected virtual void SetActiveFalseAllObjectChild()
    {
        foreach (Transform item in this.transform)
        {
            item.gameObject.SetActive(false);
        }
    }

    protected override void Start()
    {
        base.Start();

        this.CheckFirstPlaying();
    }

    protected virtual void CheckFirstPlaying()
    {
        if (GamePlayController.Instance.SystemConfig.isGuidedButton) return;

        this.gameObject.SetActive(false);
    }

    public virtual bool GetBoolActiveButton(GuidanceButtonFirstTime typeGuidance)
    {
        foreach (GuidanceButtonActive item in this._List_GuidanceButtonActive)
        {
            if (item.TypeGuidanceButton == typeGuidance) return item.ActiveButton;
        }

        return true;
    }

    protected virtual void Update()
    {
        if (!this.CheckConditionSetActiveObjectGuidance()) return;

        this.transform.GetChild(this._Order_Guidance_Current_Check).gameObject.SetActive(true);
        
        this._List_GuidanceButtonActive[this._Order_Guidance_Current_Check].ActiveButton = true;

        this._Order_Guidance_Current_Check++;

        Invoke(nameof(this.SetPauseTimeScale), 0.15f);
    }

    protected virtual void SetPauseTimeScale()
    {
        if (this._Order_Guidance_Current_Check >= this._List_GuidanceButtonActive.Count)
            Invoke(nameof(this.ActiveFalseGuidanceStarMission), 3f);

        this.SetTimeScale(0);
    }

    protected virtual void ActiveFalseGuidanceStarMission()
    {
        this.transform.GetChild(this.transform.childCount - 1).gameObject.SetActive(false);
    }    

    protected virtual void SetTimeScale(float t) => Time.timeScale = t;

    protected virtual bool CheckConditionSetActiveObjectGuidance()
    {
        if (this._Order_Guidance_Current_Check > this.transform.childCount) return false;

        return Mathf.Abs(PlayerCtrl.Instance.transform.position.x
           - this.transform.GetChild(this._Order_Guidance_Current_Check).position.x) < this._Radius_Active_Guidance;
    }

    public virtual void RestoreStatusConfigurationGuidance()
    {
        foreach (Transform item in this.transform)
        {
            item.gameObject.SetActive(false);
        }

        this.SetTimeScale(1);
    }    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public enum GuidanceButtonFirstTime
{
    Completed_Guidance = 0,

    Guidance_Jump_Button = 1,
    Guidance_Throw_Shuriken_Button = 2,
    Guidance_Dashing_Button = 3,
    Guidance_Broke_Hidden_Stone = 4,
    Guidance_Hidden_Button = 5,
    Guidance_Star_Mission = 6,
}

[Serializable]
public class GuidanceButtonActive
{
    public GuidanceButtonFirstTime TypeGuidanceButton;
    public bool ActiveButton;
}

public class GuidanceFirstTimePlaying : SurMonoBehaviour
{
    private static GuidanceFirstTimePlaying m_instance;
    public static GuidanceFirstTimePlaying Instance => m_instance;

    [SerializeField] protected float _Radius_Active_Guidance = 5;
    [SerializeField] protected List<GuidanceButtonActive> _List_GuidanceButtonActive;
    [SerializeField] protected int _Order_Guidance_Current_Check = 0;


    protected override void Awake()
    {
        base.Awake();

        if (m_instance != null) Debug.LogError("Allow only GuidanceFirstTimePlaying has been exist");

        m_instance = this;
    }

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
        if (!GamePlayController.Instance.SystemConfig.isGuidedButton) return;

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
        this.CheckAndRestoreStatusGuidance();

        if (!this.CheckConditionSetActiveObjectGuidance()) return;

        this.transform.GetChild(this._Order_Guidance_Current_Check).gameObject.SetActive(true);

        this._List_GuidanceButtonActive[this._Order_Guidance_Current_Check].ActiveButton = true;

        this._Order_Guidance_Current_Check++;

        Invoke(nameof(this.SetPauseTimeScale), 0.15f);
    }

    protected virtual void CheckAndRestoreStatusGuidance()
    {
        if (GamePlayController.Instance.SystemConfig.isGuidedButton) return;

        if (!InputManager.Instance.Press_Attack_Throw && !InputManager.Instance.Press_Attack_Dashing
        && !InputManager.Instance.Press_Hidden_Mode && !InputManager.Instance.Press_Jump) return;

        this.RestoreStatusConfigurationGuidance();
    }

    protected virtual void SetPauseTimeScale()
    {
        if (this._Order_Guidance_Current_Check >= this._List_GuidanceButtonActive.Count)
        {
            Invoke(nameof(this.ActiveFalseGuidanceStarMission), 0.5f);
        }    
            
        this.SetTimeScale(0);
    }

    protected virtual void ActiveFalseGuidanceStarMission()
    {
        this.SetTimeScale(1);

        this.transform.GetChild(this.transform.childCount - 1).gameObject.SetActive(false);
        
        GamePlayController.Instance.SystemConfig.isGuidedButton = true;

        this.gameObject.SetActive(false);
       // Debug.Log("False star mission");
    }

    protected virtual void SetTimeScale(float t) => Time.timeScale = t;

    protected virtual bool CheckConditionSetActiveObjectGuidance()
    {
        if (this._Order_Guidance_Current_Check >= this.transform.childCount) return false;

        return Mathf.Abs(PlayerCtrl.Instance.transform.position.x
           - this.transform.GetChild(this._Order_Guidance_Current_Check).position.x) < this._Radius_Active_Guidance;
    }

    public virtual void RestoreStatusConfigurationGuidance()
    {
        this.SetTimeScale(1);

        if (this._Order_Guidance_Current_Check >= this._List_GuidanceButtonActive.Count) return;

        foreach (Transform item in this.transform)
        {
            item.gameObject.SetActive(false);
        }


    }
}

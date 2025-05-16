using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHidenSkillActiveByTime : ActiveByTimer
{
    private static ButtonHidenSkillActiveByTime _instance;
    public static ButtonHidenSkillActiveByTime Instance => _instance;

    [SerializeField] protected float _Time_Delay_Button_Hiden = 5f;

    protected override void Awake()
    {
        base.Awake();

        if (_instance != null) Debug.LogError("Only InputManager was allowed existed");

        _instance = this;
    }

    protected override void ResetValue()
    {
        base.ResetValue();

        this._Time_Delay_Button_Hiden = this._ButtonActiveParent.GamePlayUIOverall.GamePlayConfigUIOverall.Time_Delay_Button_Hiden;
        this._Time_Delay_Button_Active = this._ButtonActiveParent.GamePlayUIOverall.GamePlayConfigUIOverall.Time_Delay_Active_Button_Hiden;
    }

    protected override void Update()
    {
        if (this._Timer != 0 && !this.GetBoolVariable() && !this.CheckConditionPlayer())
        {
            this.SetAllConfigurationBeforeInActiveButton();
            this.ProcedureCountDownHideButton();
            //Debug.Log("A");
            return;
        }

        if (this.GetBoolVariable() && !this.CheckTimeDelayByParameter(this._Time_Delay_Button_Hiden)) return;

        base.Update();
    }

    protected virtual bool CheckConditionPlayer()
    {
        return (PlayerCtrl.Instance.PlayerMovement.IsHiding);
    }

    protected override void SetBoolVariableFalse()
    {
        if (!PlayerCtrl.Instance.PlayerMovement.IsHiding) return;
        InputManager.Instance.PointerHidenModeSkillPresAndUp();//run more correctly than setallconfig
    }

    protected override bool GetBoolVariable()
    {
        return InputManager.Instance.Press_Hidden_Mode;
        //return !PlayerCtrl.Instance.PlayerMovement.IsHiding && InputManager.Instance.Press_Hiden_Mode;

    }
    protected override bool CheckAllPrequisite()
    {
        if (!GamePlayController.Instance.SystemConfig.isGuidedButton) 
            return GuidanceFirstTimePlaying.Instance.GetBoolActiveButton(this._Type_Guidance_Button);

        return PlayerCtrl.Instance.PlayerMovement.IsDashing || PlayerCtrl.Instance.PlayerMovement.IsStunned;
    }

    protected override void SetAllConfigurationBeforeInActiveButton()
    {
        if (this.GetBoolVariable() && this.CheckTimeDelayByParameter(this._Time_Delay_Button_Hiden)) this._Timer = 0f;

        base.SetAllConfigurationBeforeInActiveButton();
    }

    public virtual void ResetTimer() => this._Timer = 0.001f;
}

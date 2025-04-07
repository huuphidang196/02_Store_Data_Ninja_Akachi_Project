using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonThrowActiveByTime : ActiveByTimer
{
    protected override void ResetValue()
    {
        base.ResetValue();

        this._Time_Delay_Button_Active = this._ButtonActiveParent.GamePlayUIOverall.GamePlayConfigUIOverall.Time_Delay_Active_Button_Attack_Throw;
    }
    protected override void SetBoolVariableFalse()
    {
        if (!PlayerCtrl.Instance.PlayerAnimation.CheckTimer()) return;
        InputManager.Instance.PointerAttackThrowPresAndUp();//run more correctly than setallconfig
    }

    protected override bool GetBoolVariable()
    {
        return InputManager.Instance.Press_Attack_Throw;
    }
    protected override bool CheckAllPrequisite()
    {
        return PlayerCtrl.Instance.PlayerMovement.IsHiding || PlayerCtrl.Instance.PlayerMovement.IsDashing;
    }
}

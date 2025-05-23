using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDashingActiveByTime : ActiveByTimer
{
    protected override void ResetValue()
    {
        base.ResetValue();

        this._Time_Delay_Button_Active = this._ButtonActiveParent.GamePlayUIOverall.GamePlayConfigUIOverall.Time_Delay_Active_Button_Attack_Dashing; ;
    }

    protected override bool GetBoolVariable()
    {
        return InputManager.Instance.Press_Attack_Dashing ;
    }

    protected override void SetBoolVariableFalse()
    {
        InputManager.Instance.PointerAttackDashingPresAndUp();
    }
    protected override bool CheckAllPrequisite()
    {
        return PlayerCtrl.Instance.PlayerMovement.IsHiding || PlayerCtrl.Instance.PlayerMovement.IsStunned;
    }
}


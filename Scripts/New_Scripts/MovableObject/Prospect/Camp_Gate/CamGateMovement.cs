using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamGateMovement : DynamicBridgeVerticalMovement
{
    [SerializeField] protected CamGateCtrl _CamGateCtrl;
    public CamGateCtrl CamGateCtrl => _CamGateCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadCamGateCtrl();
    }

    protected virtual void LoadCamGateCtrl()
    {
        if (this._CamGateCtrl != null) return;

        this._CamGateCtrl = GetComponentInParent<CamGateCtrl>();
    }

    protected override float GetSpeedMoveVertical()
    {
        return 3f;
    }

    protected override float GetSpeedMoveHorizontal()
    {
        return 0;
    }


    protected override void FixedUpdate()
    {
        // Chuyển đổi hướng Y local thành hướng trong world space
        if (!this._CamGateCtrl.CamGateCheckControl.IsToggle || !this.MoveUp && this.transform.position.y < this._Old_Position.y)
        {
            this._Vertical = 0f;
        }
        else this._Vertical = this.MoveUp ? this._Speed_Move_Vertical : this._Speed_Move_Vertical * -1f;

        base.FixedUpdate();
    }

}

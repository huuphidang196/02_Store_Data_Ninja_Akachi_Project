using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamGateCheckControl : SurMonoBehaviour
{
    [SerializeField] protected CamGateCtrl _CamGateCtrl;
    public CamGateCtrl CamGateCtrl => _CamGateCtrl;

    [SerializeField] protected bool isToggle = true;
    public bool IsToggle => this.isToggle;

    [SerializeField] protected float _Offset_Dis_Open_X = 12f;
    public float Offset_Dis_Open => _Offset_Dis_Open_X;


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

    protected virtual void FixedUpdate()
    {
        this.isToggle = this.CheckScope();
    }
    protected virtual bool CheckScope()
    {
        if (this._CamGateCtrl.CamGateMovement.IsMoveUp
           && PlayerCtrl.Instance.transform.position.x >= (this.transform.position.x - this._Offset_Dis_Open_X) && PlayerCtrl.Instance.transform.position.x <= this.transform.position.x
            && this.transform.position.y >= this._CamGateCtrl.CamGateMovement.Old_Position.y)
            return true;

        if (!this._CamGateCtrl.CamGateMovement.IsMoveUp
          && PlayerCtrl.Instance.transform.position.x <= (this.transform.position.x + this._Offset_Dis_Open_X) && PlayerCtrl.Instance.transform.position.x >= this.transform.position.x
           && this.transform.position.y > this._CamGateCtrl.CamGateMovement.Old_Position.y)
            return true;

        return false;
    }

}

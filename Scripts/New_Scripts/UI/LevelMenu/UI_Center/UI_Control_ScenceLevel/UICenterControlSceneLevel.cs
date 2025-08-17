using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICenterControlSceneLevel : SurMonoBehaviour
{
    [SerializeField] protected UIPanelSpecifySceneCtrl _UIPanelSpecifySceneCtrl;
    public UIPanelSpecifySceneCtrl UIPanelSpecifySceneCtrl => this._UIPanelSpecifySceneCtrl;

    [SerializeField] protected Transform _Btn_Back_Stage;
    public Transform Btn_Back_Stage => this._Btn_Back_Stage;

    [SerializeField] protected Transform _Btn_Next_Stage;
    public Transform Btn_Next_Stage => this._Btn_Next_Stage;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadUIPanelSpecifySceneCtrl();
        this.LoadButtonBackStage();
        this.LoadButtonNextStage();
    }

    protected virtual void LoadButtonNextStage()
    {
        if (this._Btn_Next_Stage != null) return;

        this._Btn_Next_Stage = transform.Find("btnNextStage");
    }

    protected virtual void LoadButtonBackStage()
    {
        if (this._Btn_Back_Stage != null) return;

        this._Btn_Back_Stage = transform.Find("btnBackStage");
    }

    protected virtual void LoadUIPanelSpecifySceneCtrl()
    {
        if (this._UIPanelSpecifySceneCtrl != null) return;

        this._UIPanelSpecifySceneCtrl = GetComponentInChildren<UIPanelSpecifySceneCtrl>();
    }
}

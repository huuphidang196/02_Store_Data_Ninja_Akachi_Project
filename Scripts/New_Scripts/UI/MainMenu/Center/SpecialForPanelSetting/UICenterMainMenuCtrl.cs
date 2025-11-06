using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICenterMainMenuCtrl : SurMonoBehaviour
{
    private static UICenterMainMenuCtrl _instance;
    public static UICenterMainMenuCtrl Instance => _instance;

    [SerializeField] protected Transform _UI_Panel_Settings;
    public Transform UI_Panel_Settings => this._UI_Panel_Settings;

    [SerializeField] protected Transform _UI_Panel_ADS_Settings;
    public Transform UI_Panel_ADS_Settings => this._UI_Panel_ADS_Settings;
  
    [SerializeField] protected UICenterMainMenuManager _UICenterMainMenuManager;
    public UICenterMainMenuManager UICenterMainMenuManager => this._UICenterMainMenuManager;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadPanelSettings();
        this.LoadUICenterMainMenuManager();
        this.LoadPanelADSSetting();
    }

    protected virtual void LoadPanelADSSetting()
    {
        if (this._UI_Panel_ADS_Settings != null) return;

        this._UI_Panel_ADS_Settings = transform.Find("pnlAdsSetting");
        this._UI_Panel_ADS_Settings.gameObject.SetActive(false);
    }

    protected virtual void LoadUICenterMainMenuManager()
    {
        if (this._UICenterMainMenuManager != null) return;

        this._UICenterMainMenuManager = GetComponentInChildren<UICenterMainMenuManager>();
    }

    protected virtual void LoadPanelSettings()
    {
        if (this._UI_Panel_Settings != null) return;

        this._UI_Panel_Settings = transform.Find("pnlSettingMainMenu");
        this._UI_Panel_Settings.gameObject.SetActive(false);
    }

    protected override void Awake()
    {
        base.Awake();

        if (_instance != null) Debug.LogError("Only UICenterMainMenuCtrl was allowed existed");

        _instance = this;
    }

}

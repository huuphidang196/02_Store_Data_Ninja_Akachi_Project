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

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadPanelSettings();
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

    public virtual void ToggelPanelSettingMenu()
    {
        bool isToggle = this._UI_Panel_Settings.gameObject.activeInHierarchy;

        this._UI_Panel_Settings.gameObject.SetActive(!isToggle);
    }    
}

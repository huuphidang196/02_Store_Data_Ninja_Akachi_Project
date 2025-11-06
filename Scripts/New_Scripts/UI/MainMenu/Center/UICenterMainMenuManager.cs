using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICenterMainMenuManager : SurMonoBehaviour
{
    [SerializeField] protected UICenterMainMenuCtrl _UICenterMainMenuCtrl;
    public UICenterMainMenuCtrl UICenterMainMenuCtrl => this._UICenterMainMenuCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadUICenterMainMenuCtrl();
    }

    protected virtual void LoadUICenterMainMenuCtrl()
    {
        if (this._UICenterMainMenuCtrl != null) return;

        this._UICenterMainMenuCtrl = GetComponentInParent<UICenterMainMenuCtrl>();
    }

    public virtual void ToggelPanelSettingMenu()
    {
        bool isToggle = this._UICenterMainMenuCtrl.UI_Panel_Settings.gameObject.activeInHierarchy;

        this._UICenterMainMenuCtrl.UI_Panel_Settings.gameObject.SetActive(!isToggle);
    }

    public virtual void ToggelPanelADSSettingMenu()
    {
        this._UICenterMainMenuCtrl.UI_Panel_Settings.gameObject.SetActive(false);

        bool isToggle = this._UICenterMainMenuCtrl.UI_Panel_ADS_Settings.gameObject.activeInHierarchy;

        this._UICenterMainMenuCtrl.UI_Panel_ADS_Settings.gameObject.SetActive(!isToggle);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICenterShopManager : UICenterShopCtrlAbstract
{
    private static UICenterShopManager m_instance;
    public static UICenterShopManager Instance => m_instance;

    [SerializeField] protected bool isResources = true;
    public bool IsResources => this.isResources;

    protected override void Awake()
    {
        base.Awake();

        if (m_instance != null) Debug.LogError("Allow only UICenterShopManager has been exist");

        m_instance = this;
    }

    protected override void ResetValue()
    {
        base.ResetValue();

        this.isResources = true;
    }

    public virtual void ChangeBoolResourcesPanel(bool resource)
    {
        this.isResources = resource;
    }    

    protected virtual void FixedUpdate()
    {
        this.TogglePanelResourcesOrDisguise();
    }

    protected virtual void TogglePanelResourcesOrDisguise()
    {
        this.ToggglePanelResources();
        this.TogglePanelDisguise();
    }

    protected virtual void ToggglePanelResources()
    {
        if (this._UICenterShopCtrl.UI_Resources.gameObject.activeInHierarchy == this.isResources) return;

        this._UICenterShopCtrl.UI_Resources.gameObject.SetActive(this.isResources);
    }
    protected virtual void TogglePanelDisguise()
    {
        if (this._UICenterShopCtrl.UIShopCenterDisguiseManager.gameObject.activeInHierarchy == !this.isResources) return;

        this._UICenterShopCtrl.UIShopCenterDisguiseManager.gameObject.SetActive(!this.isResources);
    }
    
}

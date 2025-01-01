using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICenterShopCtrl : SurMonoBehaviour
{
    [SerializeField] protected Transform _UI_Resources;
    public Transform UI_Resources => this._UI_Resources;

    [SerializeField] protected UIShopCenterDisguiseManager _UIShopCenterDisguiseManager;
    public UIShopCenterDisguiseManager UIShopCenterDisguiseManager => this._UIShopCenterDisguiseManager;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadUIResources();
        this.LoadUIDisguise();
    }

    protected virtual void LoadUIResources()
    {
        if (this.UI_Resources != null) return;

        this._UI_Resources = transform.Find("UI_Resources");
    }

    protected virtual void LoadUIDisguise()
    {
        if (this._UIShopCenterDisguiseManager != null) return;

        this._UIShopCenterDisguiseManager = transform.Find("UI_Disguise").GetComponent<UIShopCenterDisguiseManager>();
    }

}

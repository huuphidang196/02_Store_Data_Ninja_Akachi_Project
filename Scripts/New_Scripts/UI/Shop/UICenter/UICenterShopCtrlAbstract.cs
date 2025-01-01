using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICenterShopCtrlAbstract : SurMonoBehaviour
{
    [SerializeField] protected UICenterShopCtrl _UICenterShopCtrl;
    public UICenterShopCtrl UICenterShopCtrl => this._UICenterShopCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadUICenterShopCtrl();
    }

    protected virtual void LoadUICenterShopCtrl()
    {
        if (this._UICenterShopCtrl != null) return;

        this._UICenterShopCtrl = GetComponentInParent<UICenterShopCtrl>();
    }
}

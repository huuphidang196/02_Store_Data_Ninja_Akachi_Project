using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILightButtonShopControl : UIButtonContainLightSelected
{
    [Header("UILightButtonShopControl")]

    [SerializeField] protected bool isSameResources;

    protected override void ResetValue()
    {
        base.ResetValue();

        this.isSameResources = transform.name.Contains("Resource");
    }

    protected virtual void FixedUpdate()
    {
        this._Light_Selected.gameObject.SetActive(this.isSameResources ? UICenterShopManager.Instance.IsResources : !UICenterShopManager.Instance.IsResources);
    }

}

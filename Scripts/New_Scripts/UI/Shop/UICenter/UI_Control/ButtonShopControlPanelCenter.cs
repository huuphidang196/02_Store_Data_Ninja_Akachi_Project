using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonShopControlPanelCenter : BaseButton 
{
    [SerializeField] protected bool isResource;

    protected override void ResetValue()
    {
        base.ResetValue();

        this.isResource = transform.name.Contains("Resource");
    }
    protected override void OnClick()
    {
        base.OnClick();

        UICenterShopManager.Instance.ChangeBoolResourcesPanel(this.isResource);
    }

}

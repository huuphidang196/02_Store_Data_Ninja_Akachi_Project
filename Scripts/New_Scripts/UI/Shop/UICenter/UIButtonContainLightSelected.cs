using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonContainLightSelected : SurMonoBehaviour
{
    [SerializeField] protected Transform _Light_Selected;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadLightSelected();
    }

    protected virtual void LoadLightSelected()
    {
        if (this._Light_Selected != null) return;

        this._Light_Selected = transform.Find("Light_Selected");
        this._Light_Selected.gameObject.SetActive(false);
    }

}

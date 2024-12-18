using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBelowCtrl : SurMonoBehaviour
{
    [SerializeField] protected Transform _Image_BG_Loading;
    public Transform Image_BG_Loading => this._Image_BG_Loading;
    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadImageBGLoading();
    }

    protected virtual void LoadImageBGLoading()
    {
        if (this._Image_BG_Loading != null) return;

        this._Image_BG_Loading = transform.Find("Image_BG_Loading");
        this._Image_BG_Loading.gameObject.SetActive(false);
    }

}

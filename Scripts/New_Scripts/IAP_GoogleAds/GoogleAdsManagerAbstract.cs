using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoogleAdsManagerAbstract : SurMonoBehaviour
{
    [SerializeField] protected GoogleAdsManager _GoogleAdsManager;
    public GoogleAdsManager GoogleAdsManager => _GoogleAdsManager;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadGoogleAdsManager();
    }

    protected virtual void LoadGoogleAdsManager()
    {
        if (this._GoogleAdsManager != null) return;

        this._GoogleAdsManager = transform.parent.GetComponent<GoogleAdsManager>();
    }
}

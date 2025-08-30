using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class GoogleAdsManager : Singleton<GoogleAdsManager>
{
    [SerializeField] protected AdmobAdsManager _AdmobAdsManager;
    public AdmobAdsManager AdmobAdsManager => this._AdmobAdsManager;

    [SerializeField] protected FirebaseRemoteConfigManager _FirebaseRemoteConfig;
    public FirebaseRemoteConfigManager FirebaseRemoteConfig => this._FirebaseRemoteConfig;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadAdmobAdsManager();
        this.LoadFirebaseRemoteConfig();
    }

    protected virtual void LoadAdmobAdsManager()
    {
        if (this._AdmobAdsManager != null) return;

        this._AdmobAdsManager = GetComponentInChildren<AdmobAdsManager>();
    }

    protected virtual void LoadFirebaseRemoteConfig()
    {
        if (this._FirebaseRemoteConfig != null) return;

        this._FirebaseRemoteConfig = GetComponentInChildren<FirebaseRemoteConfigManager>();
    }
}


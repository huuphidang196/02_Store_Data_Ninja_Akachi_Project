using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class AdmobAdsManager : GoogleAdsManagerAbstract
{
    [SerializeField] protected RewardedAd rewardedAd;

    [SerializeField] protected InterstitialAd interstitialAd; // ✅ Thêm Interstitial
    [SerializeField] protected DateTime _LastRequest_Reward_Time;
    [SerializeField] protected DateTime _LastReached_Reward_Time;
    public DateTime LastReached_Reward_Time { get => this._LastReached_Reward_Time; set => this._LastReached_Reward_Time = value; }

    [SerializeField] protected DateTime _LastRequest_Inter_Time;
    [SerializeField] protected DateTime _LastReached_Inter_Time;
    public DateTime LastReached_Inter_Time { get => this._LastReached_Inter_Time; set => this._LastReached_Inter_Time = value; }

    [Header("Config")]
    [SerializeField] protected float _MinRequestInterval = 30f;
    [SerializeField] protected float _RequestCooldown = 300f;

    [Header("Reward_ADS")]
    [SerializeField] protected int _MaxRewardedPerDay = 3;
    [SerializeField] protected int _RewardedCountToday = 0;
    public int RewardedCountToday { get => this._RewardedCountToday; set => this._RewardedCountToday = value; }


    [SerializeField] protected int _Max_Ad_Reward_Request_Once = 3;
    [SerializeField] protected int _Ad_Request_One_Count_Today_Reward = 0;

    [Header("Interstitial_ADS")]
    [SerializeField] protected int _MaxInterstitialPerDay = 4; // ✅ Giới hạn Interstitial Ads
    [SerializeField] protected int _InterstitialCountToday = 0;
    public int InterstitialCountToday { get => this._InterstitialCountToday; set => this._InterstitialCountToday = value; }

    [SerializeField] protected int _Max_Ad_Inter_Request_Once = 3;
    [SerializeField] protected int _Ad_Request_One_Count_Today_Interstitial = 0;


    [SerializeField] protected bool allowButton_Active = true;
    public bool AllowButttonActive => this.allowButton_Active;

    // Action toàn cục
    public Action OnAdRewardClosedGlobal;
    public Action OnAdInterstitialAdClosedGlobal;

#if UNITY_ANDROID
    string rewardedId_Main = "ca-app-pub-3940256099942544/1033173712";
    string interstitialId_Main = "ca-app-pub-3940256099942544/1033173712"; // test id interstitial
#elif UNITY_IPHONE
    string rewardedId = "ca-app-pub-3940256099942544/1712485313";
    string interstitialId = "ca-app-pub-3940256099942544/4411468910";
#endif

    protected override void Start()
    {
        if (this.rewardedAd != null) { rewardedAd.Destroy(); this.rewardedAd = null; }
        if (this.interstitialAd != null) { interstitialAd.Destroy(); this.interstitialAd = null; }

        MobileAds.Initialize((InitializationStatus initStatus) => { });
    }

    protected virtual void FixedUpdate()
    {
        // Cho phép nút Reward nếu có Ad và chưa mua gói remove ads
        this.allowButton_Active = this.rewardedAd != null;

        if (!this.CheckInternetConnection()) return;
        if (!this._GoogleAdsManager.FirebaseRemoteConfig.ConfigData.AllowAds) return;

        this.UpdateDataConfig();
        this.ProcessLoadWatchAds();
        this.ProcessLoadWatchInterstitialAd();
    }

    protected virtual void UpdateDataConfig()
    {
        //Overall using
        this._MinRequestInterval = this._GoogleAdsManager.FirebaseRemoteConfig.ConfigData.MinRequestInterval;
        this._RequestCooldown = this._GoogleAdsManager.FirebaseRemoteConfig.ConfigData.RequestCooldown; // vd: 300s = 5 phút

        //Reward
        this._MaxRewardedPerDay = this._GoogleAdsManager.FirebaseRemoteConfig.ConfigData.Max_Ads_Reward_View_Today;
        this._Max_Ad_Reward_Request_Once = this._GoogleAdsManager.FirebaseRemoteConfig.ConfigData.Max_Request_Once_AdsReward;

        //Interstitial
        this._MaxInterstitialPerDay = this._GoogleAdsManager.FirebaseRemoteConfig.ConfigData.Max_Ads_Interstitial_View_Today;
        this._Max_Ad_Inter_Request_Once = this._GoogleAdsManager.FirebaseRemoteConfig.ConfigData.Max_Request_Once_Interstitial;
    }

    #region ================= Reference OutSide =================
    public virtual void WatchVideoAdsEarnMoney()
    {
        this.ShowRewardAndCallBackLoadLevel();
    }

    public virtual void WatchVideoAdsAfterCompletedMissionOrEndGame()
    {
        this.ShowInterAndCallBackLoadLevel();
    }

    protected virtual void ShowRewardAndCallBackLoadLevel()
    {
        if (this.rewardedAd == null)
        {
            OnAdRewardClosedGlobal?.Invoke();
            return;
        }
        this.ShowRewardedAd();
    }
    protected virtual void ShowInterAndCallBackLoadLevel()
    {
        if (this.interstitialAd == null)
        {
            OnAdInterstitialAdClosedGlobal?.Invoke();
            return;
        }
        this.ShowInterstitialAd();
    }
    #endregion
    #region ================= Rewarded Ads =================

    protected virtual void ProcessLoadWatchAds()
    {
        if (rewardedAd != null) return;

        // ✅ Đủ số lần xem trong ngày thì thôi
        if (this._RewardedCountToday >= this._MaxRewardedPerDay) return;

        // ✅ Nếu chưa tới thời gian request lại thì bỏ qua
        if ((DateTime.Now - this._LastRequest_Reward_Time).TotalSeconds < this._MinRequestInterval) return;

        // ✅ Nếu đã quá số request liên tiếp thì cần cooldown dài hơn
        if (this._Ad_Request_One_Count_Today_Reward >= this._Max_Ad_Reward_Request_Once)
        {
            // Nếu đã hết hạn cooldown thì reset để thử lại

            if ((DateTime.Now - this._LastRequest_Reward_Time).TotalSeconds < this._RequestCooldown) return;

            // reset đếm để cho phép request tiếp
            this._Ad_Request_One_Count_Today_Reward = 0;
        }

        // ✅ Request hợp lệ
        this._Ad_Request_One_Count_Today_Reward++;
        this._LastRequest_Reward_Time = DateTime.Now;

        this.LoadRewardedAd();
    }

    public virtual void ProcessWatchRewarded(bool success)
    {
        this._Ad_Request_One_Count_Today_Reward = 0;

        if (!success) return;

        this._RewardedCountToday++;
        this.DestroyReward();
        this.GiftForUserSinceWatchADS();

        this._LastReached_Reward_Time = DateTime.Now;
        SaveManager.Instance.SaveGame();
    }

    protected virtual void GiftForUserSinceWatchADS()
    {
        ItemUnit itemMoneyUnit = new ItemUnit(100, TypeItemMoney.Diamond);
        SystemController.Sys_Instance.AddMoneyToSystem(itemMoneyUnit);
    }

    protected virtual void DestroyReward()
    {
        if (this.rewardedAd == null) return;
        rewardedAd.Destroy();
        this.rewardedAd = null;

        this._Ad_Request_One_Count_Today_Reward = 0;
    }

    public void LoadRewardedAd()
    {
        var adRequest = new AdRequest();

        RewardedAd.Load(this.rewardedId_Main, adRequest,
            (RewardedAd ad, LoadAdError error) =>
            {
                if (error != null || ad == null)
                {
                    this.ProcessWatchAdByAdmobFailure();
                    return;
                }
                rewardedAd = ad;
                RegisterRewardedHandlers(rewardedAd);

            });
    }

    protected virtual void ProcessWatchAdByAdmobFailure() { }

    public virtual void ShowRewardedAd()
    {
        if (rewardedAd != null && rewardedAd.CanShowAd())
        {
            rewardedAd.Show((Reward reward) => { });
            Debug.Log("Reward");
            return;
        }
        OnAdRewardClosedGlobal?.Invoke();
  
    }

    private void RegisterRewardedHandlers(RewardedAd ad)
    {
        ad.OnAdFullScreenContentClosed += () =>
        {
            this.ProcessWatchRewarded(true);
            OnAdRewardClosedGlobal?.Invoke();
        };
        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            this.ProcessWatchRewarded(false);
            this.DestroyReward();
            OnAdRewardClosedGlobal?.Invoke();
        };
    }
    #endregion

    #region ================= Interstitial Ads =================
    protected virtual void ProcessLoadWatchInterstitialAd()
    {
        //For endgame or load new scene using interstitial
        if (SystemController.Sys_Instance.SystemConfig.ShopControllerSO.WasRemoved_AdsInterstitial)
        {
            this.interstitialAd = null;
            return;
        }
        if (this.interstitialAd != null) return;

        // ✅ Đủ số lần xem trong ngày thì thôi
        if (this._InterstitialCountToday >= this._MaxInterstitialPerDay) return;

        // ✅ Nếu chưa tới thời gian request lại thì bỏ qua
        if ((DateTime.Now - this._LastRequest_Inter_Time).TotalSeconds < this._MinRequestInterval) return;

        // ✅ Nếu đã quá số request liên tiếp thì cần cooldown dài hơn
        if (this._Ad_Request_One_Count_Today_Interstitial >= this._Max_Ad_Inter_Request_Once)
        {
            if ((DateTime.Now - this._LastRequest_Inter_Time).TotalSeconds < this._RequestCooldown) return;

            // reset đếm để cho phép request tiếp
            this._Ad_Request_One_Count_Today_Interstitial = 0;
        }

        // ✅ Request hợp lệ
        this._Ad_Request_One_Count_Today_Interstitial++;
        this._LastRequest_Inter_Time = DateTime.Now;

        this.LoadInterstitialAd();
    }

    public void LoadInterstitialAd()
    {
        var adRequest = new AdRequest();
        InterstitialAd.Load(this.interstitialId_Main, adRequest,
            (InterstitialAd ad, LoadAdError error) =>
            {
                if (error != null || ad == null) return;
                interstitialAd = ad;
                RegisterInterstitialHandlers(interstitialAd);
            });
    }

    public void ShowInterstitialAd()
    {
        if (interstitialAd != null && interstitialAd.CanShowAd())
        {
            interstitialAd.Show();
            Debug.Log("Inter");
            return;
        }
       
        OnAdInterstitialAdClosedGlobal?.Invoke();
       
    }

    private void RegisterInterstitialHandlers(InterstitialAd ad)
    {
        ad.OnAdFullScreenContentClosed += () =>
        {
            this._InterstitialCountToday++;
            this.DestroyInterstitial();

            OnAdInterstitialAdClosedGlobal?.Invoke();
            this._LastReached_Inter_Time = DateTime.Now;
        };
        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            interstitialAd = null;
            OnAdInterstitialAdClosedGlobal?.Invoke();
            // reset đếm để cho phép request tiếp
            this._Ad_Request_One_Count_Today_Interstitial = 0;
        };
    }

    protected virtual void DestroyInterstitial()
    {
        if (this.interstitialAd == null) return;

        interstitialAd.Destroy();
        interstitialAd = null;

        // reset đếm để cho phép request tiếp
        this._Ad_Request_One_Count_Today_Interstitial = 0;
    }
    #endregion

    public virtual bool CheckInternetConnection()
    {
        return Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork ||
               Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork;
    }
}

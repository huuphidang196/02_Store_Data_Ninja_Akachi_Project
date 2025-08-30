using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class AdmobAdsManager : GoogleAdsManagerAbstract
{

    [SerializeField] protected bool isWatchGift = false;
    [SerializeField]
    protected RewardedAd rewardedAd;
    public RewardedAd RewardedAd => this.rewardedAd;

    [SerializeField]
    protected DateTime _LastRequestTime;

    [SerializeField]
    protected DateTime _LastReachADS_Time;
    public DateTime LastReachADS_Time => this._LastReachADS_Time;

    [SerializeField]
    protected float _MinRequestInterval = 30f; // Thời gian tối thiểu giữa 2 lần request

    [SerializeField]
    protected int _MaxAdViewsPerDay = 9;

    [SerializeField]
    protected int _AdViewCountToday = 0;//Save
    public int ADS_View_Count_today => this._AdViewCountToday;

    [SerializeField] protected int _Max_Ad_Request_Once = 4;
    [SerializeField] protected int _Ad_Request_One_Count_Today = 0;

    [SerializeField] protected bool allowButton_Active = true;
    public bool AllowButttonActive => this.allowButton_Active;


    // Action toàn cục
    public Action OnAdClosedGlobal;

#if UNITY_ANDROID
    string rewardedId_Main = "ca-app-pub-3940256099942544/1033173712";

#elif UNITY_IPHONE
    string rewardedId = "ca-app-pub-3940256099942544/1712485313";

#endif

    protected override void Start()
    {
        if (this.rewardedAd != null)
        {
            rewardedAd.Destroy();
            this.rewardedAd = null;

        }

        this._LastReachADS_Time = DateTime.Now;

        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize((InitializationStatus initStatus) =>
        {
            //Load Ad

            // this.LoadRewardedAd();
            // this.LoadLoadInterstitialAd();
        });

    }

    public virtual void SetAdviewCountToday(int viewCount)
    {
        this._AdViewCountToday = viewCount;
        this._LastRequestTime = DateTime.Now;

    }

    protected virtual void FixedUpdate()
    {
        this.ProcessLoadWatchAds();

        this.allowButton_Active = this.rewardedAd != null;
    }

    public virtual void WatchVideoAdsEarnMoney()
    {
        this.isWatchGift = true;

        this.ShowRewardAndCallBackLoadLevel();
    }

    public virtual void WatchVideoAdsAfterCompletedMissionOrEndGame()
    {
        this.isWatchGift = false;

        this.ShowRewardAndCallBackLoadLevel();
        // Debug.Log("Watch");
    }

    protected virtual void ShowRewardAndCallBackLoadLevel()
    {
        if (this.rewardedAd == null)
        {
            OnAdClosedGlobal?.Invoke();
            return;
        }
        this.ShowRewardedAd();

    }

    public virtual bool CheckInternetConnection()
    {
        if (Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork ||
            Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork)

            return true;

        return false;

    }

    protected virtual void ProcessLoadWatchAds()
    {
        //These instructions only apply for allowing btn watch ads.
        if (!this.CheckInternetConnection()) return;

        if (!this._GoogleAdsManager.FirebaseRemoteConfig.ConfigData.AllowAds) return;

        if (rewardedAd != null) return;

        this._MaxAdViewsPerDay = this._GoogleAdsManager.FirebaseRemoteConfig.ConfigData.Max_Ads_View_Today;
        this._Max_Ad_Request_Once = this._GoogleAdsManager.FirebaseRemoteConfig.ConfigData.Max_Request_Once;

        //Donnot allow user watch ads since reached limit
        if (this._AdViewCountToday >= this._MaxAdViewsPerDay) return;

        //Debug.Log("Đợi thêm trước khi request lại.");
        if ((DateTime.Now - this._LastRequestTime).TotalSeconds > this._MinRequestInterval)
        {
            this._Ad_Request_One_Count_Today = 0;
        }

        if (this._Ad_Request_One_Count_Today >= this._Max_Ad_Request_Once) return;

        this._Ad_Request_One_Count_Today++;
        this._LastRequestTime = DateTime.Now;

        this.LoadRewardedAd();
        return;
    }

    public virtual void ProcessWatchAdvertisement(bool watchSuccess)
    {
        //must give ID because Ad load faild => user select other button 
        //bool watchSuccess = this.WatchAdvertisementAndReponse();

        //Watch success => add List Purchased
        if (!watchSuccess) return;

        this._AdViewCountToday++;
        this._LastReachADS_Time = DateTime.Now;

        this._Ad_Request_One_Count_Today = 0;

        this.DestroyReward();

        if (this.isWatchGift) this.GiftForUserSinceWatchADS();

        SaveManager.Instance.SaveGame();
    }

    protected virtual void GiftForUserSinceWatchADS()
    {
        ItemUnit itemMoneyUnit = new ItemUnit(100, TypeItemMoney.Diamond);
        SystemController.Sys_Instance.AddMoneyToSystem(itemMoneyUnit);
    }

    #region Rewarded
    protected virtual void DestroyReward()
    {
        //Prepare Ad
        if (this.rewardedAd == null) return;

        rewardedAd.Destroy();
        this.rewardedAd = null;
    }
    public void LoadRewardedAd()
    {
        // create our request used to load the ad.
        var adRequest = new AdRequest();

        // send the request to load the ad.
        RewardedAd.Load(this.rewardedId_Main, adRequest,
            (RewardedAd ad, LoadAdError error) =>
            {
                // if error is not null, the load request failed.
                if (error != null || ad == null)
                {
                    this.ProcessWatchAdByAdmobFailure();
                    return;
                }
                Debug.Log("Loaded Ad");
                rewardedAd = ad;
                RegisterEventHandlers(rewardedAd);
            });
    }
    protected virtual void ProcessWatchAdByAdmobFailure()
    {
        //Process load failed;
    }

    public virtual void ShowRewardedAd()
    {
        if (rewardedAd != null && rewardedAd.CanShowAd())
        {
            rewardedAd.Show((Reward reward) =>
            {


                //     OnAdClosedGlobal?.Invoke();

            });
            return;
        }

        OnAdClosedGlobal?.Invoke();
    }

    public virtual void EnableOrDisableButtonWatchAd(bool active) => this.allowButton_Active = active;

    private void RegisterEventHandlers(RewardedAd ad)
    {
        // Raised when the ad is estimated to have earned money.
        ad.OnAdPaid += (AdValue adValue) =>
        {
            //Debug.Log(String.Format("Rewarded ad paid {0} {1}.", adValue.Value, adValue.CurrencyCode));
        };
        // Raised when an impression is recorded for an ad.
        ad.OnAdImpressionRecorded += () =>
        {
            // Debug.Log("Rewarded ad recorded an impression.");
        };
        // Raised when a click is recorded for an ad.
        ad.OnAdClicked += () =>
        {
            //  this.EnableOrDisableButtonWatchAd(false);
        };
        // Raised when an ad opened full screen content.
        ad.OnAdFullScreenContentOpened += () =>
        {
            //  Debug.Log("Rewarded ad full screen content opened.");
        };
        // Raised when the ad closed full screen content.
        ad.OnAdFullScreenContentClosed += () =>
        {
            //Debug.Log("Rewarded ad full screen content closed.");
            // TODO: Reward the user.
            this.ProcessWatchAdvertisement(true);
           // this.DestroyReward();
            OnAdClosedGlobal?.Invoke();
        };
        // Raised when the ad failed to open full screen content.
        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            this.DestroyReward();
            // Nếu không có quảng cáo thì vẫn gọi để không kẹt
            OnAdClosedGlobal?.Invoke();
        };
    }

    #endregion

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using GoogleMobileAds.Api;

public class GoogleAdsManager : Singleton<GoogleAdsManager>
{

    // private RewardedAd rewardedAd;
    [SerializeField] protected bool isWatchGift = false;
    //[SerializeField]
    //   protected RewardedAd rewardedAd;
    // public RewardedAd RewardedAd => this.rewardedAd;

    [SerializeField]
    protected DateTime _LastRequestTime;

    [SerializeField]
    protected DateTime _LastReachADS_Time;
    public DateTime LastReachADS_Time => this._LastReachADS_Time;

    [SerializeField]
    protected float _MinRequestInterval = 3f; // Thời gian tối thiểu giữa 2 lần request

    [SerializeField]
    protected int _MaxAdViewsPerDay = 7;

    [SerializeField]
    protected int _AdViewCountToday = 0;//Save
    public int ADS_View_Count_today => this._AdViewCountToday;

    [SerializeField] protected int _Max_Ad_Request_Once = 5;
    [SerializeField] protected int _Ad_Request_Count_Today = 0;

    [SerializeField] protected bool allowButton_Active = false;
    public bool AllowButttonActive => this.allowButton_Active;

    public virtual void LoadVideoAdsEarnMoney()
    {

    }

    public virtual void WatchVideoAdsEarnMoney(Action onAdFinished)
    {
        this.isWatchGift = true;

        this.ShowRewardedAd(onAdFinished);
    }

    public virtual void WatchVideoAdsAfterCompletedMissionOrEndGame(Action onAdFinished)
    {
        this.isWatchGift = false;

        this.ShowRewardedAd(onAdFinished);
        // Debug.Log("Watch");
    }


    protected override void Start()
    {
        if (!this.CheckInternetConnection()) return;

        //MobileAds.Initialize(initStatus => { LoadRewardedAd(); });
    }
    public virtual bool CheckInternetConnection()
    {
        if (Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork ||
            Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork)

            return true;

        return false;

    }

    //public void LoadRewardedAd()
    //{
    //    string adUnitId = "ca-app-pub-xxxxxxxxxxxxxxxx/xxxxxxxxxx"; // Thay bằng ID quảng cáo thật
    //    rewardedAd = new RewardedAd(adUnitId);

    //    rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
    //    rewardedAd.OnAdClosed += HandleRewardAdClosed;
    //    rewardedAd.OnAdFailedToLoad += HandleRewardAdFailedToLoad;

    //    AdRequest request = new AdRequest.Builder().Build();
    //    rewardedAd.LoadAd(request);
    //}

    public void ShowRewardedAd(Action onAdFinished)
    {
        /*
        if (rewardedAd != null && rewardedAd.IsLoaded())
        {
            rewardedAd.OnAdClosed += (sender, args) => onAdFinished(); // Gọi hàm khi quảng cáo đóng
            rewardedAd.Show();
        }
        else
        {
            Debug.Log("Quảng cáo chưa load hoặc bị lỗi!");
            onAdFinished(); // Nếu quảng cáo không có, chuyển cảnh ngay lập tức
        }
        */
        //   onAdFinished();
    }

    //private void HandleUserEarnedReward(object sender, Reward args)
    //{
    //    Debug.Log("Người chơi đã xem hết quảng cáo và nhận thưởng!");
    //}

    //private void HandleRewardAdClosed(object sender, EventArgs args)
    //{
    //    LoadRewardedAd(); // Tải quảng cáo mới sau khi đóng
    //}

    //private void HandleRewardAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    //{
    //    Debug.Log("Quảng cáo không tải được: " + args.LoadAdError);
    //}
}

#if UNITY_ANDROID
//  string rewardedId_Test = "ca-app-pub-3940256099942544/5224354917";
//  string rewardedId_Main = "ca-app-pub-3940256099942544/5224354917";

#elif UNITY_IPHONE
    string rewardedId = "ca-app-pub-3940256099942544/1712485313";

#endif

//    protected override void Start()
//    {
//        if (this.rewardedAd != null)
//        {
//            rewardedAd.Destroy();
//            this.rewardedAd = null;

//        }

//        this._LastReachADS_Time = DateTime.Now;

//        // Initialize the Google Mobile Ads SDK.
//        MobileAds.Initialize((InitializationStatus initStatus) =>
//        {
//            //Load Ad

//            // this.LoadRewardedAd();
//            // this.LoadLoadInterstitialAd();
//        });

//    }

//    public virtual void SetAdviewCountToday(int viewCount)
//    {
//        this._AdViewCountToday = viewCount;
//        this._LastRequestTime = DateTime.Now;

//    }

//    protected virtual void FixedUpdate()
//    {
//        if (!this.ProcessLoadWatchAds()) return;

//        this.allowButton_Active = this._AdViewCountToday < this._MaxAdViewsPerDay || this._Ad_Request_Count_Today < this._Max_Ad_Request_Once
//            || this.rewardedAd != null || AdsUnityManager.Instance.RewardUnityAds.AllowAdsUnity;
//    }

//    protected virtual bool ProcessLoadWatchAds()
//    {
//        if (!GoogleAdsManager.Instance.CheckConnection.CheckInternetConnection()) return true;

//        this._MaxAdViewsPerDay = this.GoogleAdsManager.AdsRemoteConfig.ConfigData.Max_Ads_View_Today;
//        this._Max_Ad_Request_Once = this.GoogleAdsManager.AdsRemoteConfig.ConfigData.Max_Request_Once;

//        //Donnot allow user watch ads since reached limit
//        if (this._AdViewCountToday >= this._MaxAdViewsPerDay)
//        {
//            this.allowButton_Active = false;
//            return false;
//        }
//        if (this._Ad_Request_Count_Today >= this._Max_Ad_Request_Once)
//        {
//            this.allowButton_Active = false;
//            return false;
//        }
//        if ((DateTime.Now - this._LastRequestTime).TotalSeconds < this._MinRequestInterval)
//        {
//            //Debug.Log("Đợi thêm trước khi request lại.");
//            return true;
//        }

//        if (rewardedAd != null) return true;

//        this._Ad_Request_Count_Today++;
//        this._LastRequestTime = DateTime.Now;

//        this.LoadRewardedAd();
//        return true;
//    }

//    public virtual void ProcessWatchAdvertisement(bool watchSuccess)
//    {
//        //must give ID because Ad load faild => user select other button 
//        //bool watchSuccess = this.WatchAdvertisementAndReponse();

//        int caseContent;
//        //Watch success => add List Purchased
//        if (watchSuccess)
//        {
//            ItemProfileSO itemProfileSO = MySystemCtrl.InstanceMySystemCtrl.GetMoneysItemByItemCode(ItemCode.GoldOre);
//            int oldCounnt = itemProfileSO.Count;
//            itemProfileSO.Count = oldCounnt + 1000;

//            caseContent = 1;

//            this._AdViewCountToday++;
//            this._LastReachADS_Time = DateTime.Now;

//            this._Ad_Request_Count_Today = 0;

//            this.DestroyReward();

//            SaveManager.Instance.SaveGame();
//        }
//        else caseContent = 2;

//        LobbyUICenterManager.Instance.SetContentPanelNotifyAds(caseContent);
//        //Call event
//        GoogleAdsManager.Instance.CallPurchaseEvent();
//        // Debug.Log("watchSuccess = " + watchSuccess);

//    }

//    #region Rewarded
//    protected virtual void DestroyReward()
//    {
//        //Prepare Ad
//        rewardedAd.Destroy();
//        this.rewardedAd = null;
//    }
//    public void LoadRewardedAd()
//    {
//        // Clean up the old ad before loading a new one.
//        LobbyUICenterManager.Instance.SetContentPanelNotifyAds(3);

//        // create our request used to load the ad.
//        var adRequest = new AdRequest();

//        // send the request to load the ad.
//        RewardedAd.Load(this.GetIDReward(), adRequest,
//            (RewardedAd ad, LoadAdError error) =>
//            {
//                // if error is not null, the load request failed.
//                if (error != null || ad == null)
//                {
//                    this.ProcessWatchAdByAdmobFailure();
//                    return;
//                }

//                rewardedAd = ad;
//                RegisterEventHandlers(rewardedAd);
//            });
//    }

//    protected virtual string GetIDReward()
//    {
//        bool test_Ads = this.GoogleAdsManager.AdsRemoteConfig.ConfigData.TestAds;
//        return test_Ads ? this.rewardedId_Test : this.rewardedId_Main;
//    }

//    protected virtual void ProcessWatchAdByAdmobFailure()
//    {
//        AdsUnityManager.Instance.RewardUnityAds.LoadRewardAd();
//    }

//    public virtual void ShowRewardedAd()
//    {
//        if (rewardedAd != null && rewardedAd.CanShowAd())
//        {
//            rewardedAd.Show((Reward reward) =>
//            {

//            });
//            return;
//        }

//        if (!AdsUnityManager.Instance.RewardUnityAds.AllowAdsUnity) return;

//        AdsUnityManager.Instance.RewardUnityAds.ShowAd();
//    }

//    public virtual void EnableOrDisableButtonWatchAd(bool active) => this.allowButton_Active = active;

//    private void RegisterEventHandlers(RewardedAd ad)
//    {
//        // Raised when the ad is estimated to have earned money.
//        ad.OnAdPaid += (AdValue adValue) =>
//        {
//            //Debug.Log(String.Format("Rewarded ad paid {0} {1}.", adValue.Value, adValue.CurrencyCode));
//        };
//        // Raised when an impression is recorded for an ad.
//        ad.OnAdImpressionRecorded += () =>
//        {
//            // Debug.Log("Rewarded ad recorded an impression.");
//        };
//        // Raised when a click is recorded for an ad.
//        ad.OnAdClicked += () =>
//        {
//            //  this.EnableOrDisableButtonWatchAd(false);
//        };
//        // Raised when an ad opened full screen content.
//        ad.OnAdFullScreenContentOpened += () =>
//        {
//            //  Debug.Log("Rewarded ad full screen content opened.");
//        };
//        // Raised when the ad closed full screen content.
//        ad.OnAdFullScreenContentClosed += () =>
//        {
//            //Debug.Log("Rewarded ad full screen content closed.");
//            // TODO: Reward the user.
//            this.ProcessWatchAdvertisement(true);

//            ////transfer interstitial Ads 
//            //  this.EnableOrDisableButtonWatchAd(true);      
//        };
//        // Raised when the ad failed to open full screen content.
//        ad.OnAdFullScreenContentFailed += (AdError error) =>
//        {
//            this.DestroyReward();
//            //  Debug.LogError("Rewarded ad failed to open full screen content " +     "with error : " + error);
//            // this._btnWatchAd.interactable = true;
//        };
//    }

//    #endregion
//*/
//}

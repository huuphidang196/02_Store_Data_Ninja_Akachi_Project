using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using GoogleMobileAds.Api;

public class GoogleAdsManager : Singleton<GoogleAdsManager>
{
    // private RewardedAd rewardedAd;
    [SerializeField] protected bool isWatchGift = false;

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


    //private void Start()
    //{
    //    MobileAds.Initialize(initStatus => { LoadRewardedAd(); });
    //}

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

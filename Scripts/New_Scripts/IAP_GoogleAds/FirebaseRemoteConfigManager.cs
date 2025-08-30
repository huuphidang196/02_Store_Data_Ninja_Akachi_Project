using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading.Tasks;

using Firebase.Extensions;
using Firebase.RemoteConfig;
[Serializable]
public class ConfigData
{
    public bool AllowAds = true;
    public int Max_Ads_View_Today = 9;
    public int Max_Request_Once = 3;
}
public class FirebaseRemoteConfigManager : GoogleAdsManagerAbstract
{
    
    [SerializeField] protected ConfigData _ConfigData;
    public ConfigData ConfigData => this._ConfigData;
    
    protected override void Start()
    {
        if (!this._GoogleAdsManager.AdmobAdsManager.CheckInternetConnection()) return;

        // print("json:" + JsonUtility.ToJson(this._ConfigData));
        this.CheckRemoteConfigValues();
    }

    public Task CheckRemoteConfigValues()
    {
        // Debug.Log("Fetching data...");
        Task fetchTask = FirebaseRemoteConfig.DefaultInstance.FetchAsync(TimeSpan.Zero);
        return fetchTask.ContinueWithOnMainThread(FetchComplete);
    }
    private void FetchComplete(Task fetchTask)
    {
        if (!fetchTask.IsCompleted)
        {
            //Debug.LogError("Retrieval hasn't finished.");
            return;
        }

        var remoteConfig = FirebaseRemoteConfig.DefaultInstance;
        var info = remoteConfig.Info;
        if (info.LastFetchStatus != LastFetchStatus.Success)
        {
            // Debug.LogError($"{nameof(FetchComplete)} was unsuccessful\n{nameof(info.LastFetchStatus)}: {info.LastFetchStatus}");
            return;
        }

        // Fetch successful. Parameter values must be activated to use.
        remoteConfig.ActivateAsync()
          .ContinueWithOnMainThread(
            task => {
                //   Debug.Log($"Remote data loaded and ready for use. Last fetch time {info.FetchTime}.");

                string configData = remoteConfig.GetValue("ADS_Config_Data").StringValue;
                this._ConfigData = JsonUtility.FromJson<ConfigData>(configData);
/*
               print("Total values: "+remoteConfig.AllValues.Count);

                  foreach (var item in remoteConfig.AllValues)
                  {
                      print("Key :" + item.Key);
                      print("Value: " + item.Value.StringValue);
                  }
*/
           });

    }

}

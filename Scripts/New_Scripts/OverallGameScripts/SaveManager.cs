using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager : Singleton<SaveManager>
{
    //private static SaveManager instance;
    //public static SaveManager Instance => instance;

    private string savePath => Path.Combine(Application.persistentDataPath, "saveData5.json");

    [SerializeField] protected SaveData saveData = new SaveData();
    public SaveData DataSaved => this.saveData;

    //protected override void Awake()
    //{
    //    base.Awake();

    //    if (instance != null) Debug.LogError("Allow only SaveManager has been exist");

    //    instance = this;
    //}

    protected override void Start()
    {
        base.Start();

        if (this.saveData.systemConfigData.Level_Unlock != 0) return;

        this.LoadGame();
    }

    public virtual void SaveGame()
    {
        this.saveData = new SaveData();

        if (SystemController.Sys_Instance == null) return;
        this.ProgressSaveGame();

        string json = JsonUtility.ToJson(saveData, true);
        File.WriteAllText(savePath, json);
        Debug.Log($"Game saved to {savePath}");
    }

    protected virtual void ProgressSaveGame()
    {
        //FirstPlayting and guided button 
        this.saveData.systemConfigData.isFinishedStory = SystemController.Sys_Instance.SystemConfig.isFinishedStory;
        this.saveData.systemConfigData.isGuidedButton = SystemController.Sys_Instance.SystemConfig.isGuidedButton;

        //pLayer and Shuriken
        this.saveData.playerData.Max_Life = SystemController.Sys_Instance.SystemConfig.PlayerSO.Max_Life;
        this.saveData.playerData.Shuriken_Dam_Send = SystemController.Sys_Instance.SystemConfig.PlayerSO.ShurikenSO.Damage_Send;

        //SystemConfig SO
        this.saveData.systemConfigData.Level_Unlock = SystemController.Sys_Instance.SystemConfig.Level_Unlock;

        foreach (StarMissionLevel item in SystemController.Sys_Instance.SystemConfig.StarMissionLevels)
        {
            this.saveData.systemConfigData.StarMissionLevels.Add(item);
        }

        this.saveData.systemConfigData.Total_Golds = SystemController.Sys_Instance.SystemConfig.Total_Golds;
        this.saveData.systemConfigData.Total_Diamonds = SystemController.Sys_Instance.SystemConfig.Total_Diamonds;

        //GamePlayUI Overall
        this.saveData.GamePlayConfigUIOverallData.Time_Delay_Active_Button_Hiden = SystemController.Sys_Instance.SystemConfig.GamePlayConfigUIOverall.Time_Delay_Active_Button_Hiden;
        this.saveData.GamePlayConfigUIOverallData.Time_Delay_Active_Button_Attack_Throw = SystemController.Sys_Instance.SystemConfig.GamePlayConfigUIOverall.Time_Delay_Active_Button_Attack_Throw;
        this.saveData.GamePlayConfigUIOverallData.Time_Delay_Active_Button_Attack_Dashing = SystemController.Sys_Instance.SystemConfig.GamePlayConfigUIOverall.Time_Delay_Active_Button_Attack_Dashing;

        //Shop
        this.saveData.ShopData.WasRemoved_Ads = SystemController.Sys_Instance.SystemConfig.ShopControllerSO.WasRemoved_Ads;
        this.saveData.ShopData.Order_Skin_Equipped = SystemController.Sys_Instance.SystemConfig.ShopControllerSO.DisguiseConfigSO.Order_Skin_Equipped;

        foreach (SkinHidenMode item in SystemController.Sys_Instance.SystemConfig.ShopControllerSO.DisguiseConfigSO.Skins_Hiden_Mode)
        {
            this.saveData.ShopData.Skins_Hiden_Mode.Add(item.BaseDataUnlock);
        }

        //Artifact
        foreach (ArtifactItem item in SystemController.Sys_Instance.SystemConfig.ArtifactConfigSO.List_ArtifactItems)
        {
            BaseDataUnlock baseDataUnlock = new BaseDataUnlock(item.TypeNameArtifact.ToString(), item.Unlock);
            // Debug.Log("Name: " + baseDataUnlock.Name_Data + ", bool: " + baseDataUnlock.Unlock);
            this.saveData.ArtifactData.List_ArtifactItems.Add(baseDataUnlock);
        }
    }

    public virtual void LoadGame()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            this.saveData = JsonUtility.FromJson<SaveData>(json);

            if (SystemController.Sys_Instance == null) return;
            this.ProgressLoadGame();
            //   Debug.Log("Game loaded successfully.");
        }
        else
        {
            //  Debug.LogWarning("No save file found.");
        }
    }

    protected virtual void ProgressLoadGame()
    {
        //FirstPlayting and guided button 
        SystemController.Sys_Instance.SystemConfig.isFinishedStory = this.saveData.systemConfigData.isFinishedStory;
        SystemController.Sys_Instance.SystemConfig.isGuidedButton = this.saveData.systemConfigData.isGuidedButton;

        //pLayer and Shuriken
        SystemController.Sys_Instance.SystemConfig.PlayerSO.Max_Life = this.saveData.playerData.Max_Life;
        SystemController.Sys_Instance.SystemConfig.PlayerSO.ShurikenSO.Damage_Send = this.saveData.playerData.Shuriken_Dam_Send;

        //SystemConfig SO
        //Must set level unlock first cause count of starsMission have to set before
        SystemController.Sys_Instance.SystemConfig.SetLevelUnlock(this.saveData.systemConfigData.Level_Unlock);

        foreach (StarMissionLevel item in this.saveData.systemConfigData.StarMissionLevels)
        {
            SystemController.Sys_Instance.SystemConfig.SetCountStarMissionByLevel(item.Level_Mission, item.Count_Star_Acquired);
        }

        SystemController.Sys_Instance.SystemConfig.Total_Golds = this.saveData.systemConfigData.Total_Golds;
        SystemController.Sys_Instance.SystemConfig.Total_Diamonds = this.saveData.systemConfigData.Total_Diamonds;

        //GamePlayUI Overall
        SystemController.Sys_Instance.SystemConfig.GamePlayConfigUIOverall.Time_Delay_Active_Button_Hiden = this.saveData.GamePlayConfigUIOverallData.Time_Delay_Active_Button_Hiden;
        SystemController.Sys_Instance.SystemConfig.GamePlayConfigUIOverall.Time_Delay_Active_Button_Attack_Throw = this.saveData.GamePlayConfigUIOverallData.Time_Delay_Active_Button_Attack_Throw;
        SystemController.Sys_Instance.SystemConfig.GamePlayConfigUIOverall.Time_Delay_Active_Button_Attack_Dashing = this.saveData.GamePlayConfigUIOverallData.Time_Delay_Active_Button_Attack_Dashing;

        //Shop
        SystemController.Sys_Instance.SystemConfig.ShopControllerSO.WasRemoved_Ads = this.saveData.ShopData.WasRemoved_Ads;
        SystemController.Sys_Instance.SystemConfig.ShopControllerSO.DisguiseConfigSO.Order_Skin_Equipped = this.saveData.ShopData.Order_Skin_Equipped;

        foreach (SkinHidenMode item in SystemController.Sys_Instance.SystemConfig.ShopControllerSO.DisguiseConfigSO.Skins_Hiden_Mode)
        {
            BaseDataUnlock data = this.saveData.ShopData.Skins_Hiden_Mode.Find(x => x.Name_Data == item.BaseDataUnlock.Name_Data);
            if (data == null)
            {
                item.BaseDataUnlock.Unlock = false;
                continue;
            }
            item.BaseDataUnlock.Unlock = data.Unlock;
        }

        //Artifact
        foreach (ArtifactItem item in SystemController.Sys_Instance.SystemConfig.ArtifactConfigSO.List_ArtifactItems)
        {
            BaseDataUnlock data = this.saveData.ArtifactData.List_ArtifactItems.Find(x => x.Name_Data == item.TypeNameArtifact.ToString());
            if (data == null) continue;

            item.Unlock = data.Unlock;
        }

    }

}

[System.Serializable]
public class SaveData
{
    public PlayerData playerData = new PlayerData();
    public SystemConfigData systemConfigData = new SystemConfigData();
    public GamePlayConfigUIOverallData GamePlayConfigUIOverallData = new GamePlayConfigUIOverallData();
    public ShopData ShopData = new ShopData();
    public ArtifactData ArtifactData = new ArtifactData();
}

[System.Serializable]
public class PlayerData
{
    public int Max_Life;
    public float Shuriken_Dam_Send;
}

[System.Serializable]
public class SystemConfigData
{
    public bool isFinishedStory;
    public bool isGuidedButton;
    public List<StarMissionLevel> StarMissionLevels = new List<StarMissionLevel>();
    public int Level_Unlock;
    public float Total_Golds;
    public float Total_Diamonds;
}

[System.Serializable]
public class GamePlayConfigUIOverallData
{
    public float Time_Delay_Active_Button_Hiden;
    public float Time_Delay_Active_Button_Attack_Throw;
    public float Time_Delay_Active_Button_Attack_Dashing;
}

[System.Serializable]
public class ShopData
{
    public bool WasRemoved_Ads;
    public int Order_Skin_Equipped;
    public List<BaseDataUnlock> Skins_Hiden_Mode = new List<BaseDataUnlock>();
}

[System.Serializable]
public class ArtifactData
{
    public List<BaseDataUnlock> List_ArtifactItems = new List<BaseDataUnlock>();
}


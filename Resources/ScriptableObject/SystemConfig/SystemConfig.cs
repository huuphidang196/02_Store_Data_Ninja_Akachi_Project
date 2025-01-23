using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SystemConfig", menuName = "ScriptableObject/Configuration/SystemConfig")]
public class SystemConfig : ScriptableObject
{
    [SerializeField] protected List<StarMissionLevel> _StarMissionLevels;
    public List<StarMissionLevel> StarMissionLevels
    {
        get
        {
            if (this._StarMissionLevels.Count == 0) this._StarMissionLevels.Add(new StarMissionLevel(1, 0));
            return this._StarMissionLevels;
        }
    }

    public int Current_Level;

    protected int _Level_Unlock;

    public int Level_Unlock
    {
        get { return (this._Level_Unlock > 0) ? this._Level_Unlock : 1; }
    }
    public virtual void SetLevelUnlock()
    {
        this.SetLevelUnlock(this.Current_Level + 1);
    }

    public virtual void SetLevelUnlock(int levelSet)
    {
        //also for using SaveManager set together
        if (levelSet <= this.Level_Unlock) return;

        this._Level_Unlock = levelSet;
        if (this._StarMissionLevels.Count >= this._Level_Unlock) return;

        for (int i = this._StarMissionLevels.Count - 1; i < this._Level_Unlock; i++)
        {
            this._StarMissionLevels.Add(new StarMissionLevel(i + 1, 0));
        }

    }

    public float Total_Golds;
    public float Total_Diamonds;

    [SerializeField] protected GameConfigController _GameConfigController;
    public GameConfigController GameConfigController => this._GameConfigController;

    [SerializeField] protected GamePlayConfigUIOverall _GamePlayConfigUIOverall;
    public GamePlayConfigUIOverall GamePlayConfigUIOverall => this._GamePlayConfigUIOverall;

    [SerializeField] protected SoundCtrlSO _SoundCtrlSO;
    public SoundCtrlSO SoundCtrlSO => this._SoundCtrlSO;

    [SerializeField] protected ShopControllerSO _ShopControllerSO;
    public ShopControllerSO ShopControllerSO => this._ShopControllerSO;

    [SerializeField] protected ArtifactConfigSO _ArtifactConfigSO;
    public ArtifactConfigSO ArtifactConfigSO => this._ArtifactConfigSO;

    [SerializeField] protected PlayerSO _PlayerSO;
    public PlayerSO PlayerSO => this._PlayerSO;

    public virtual StarMissionLevel GetStarMissionByLevel(int level)
    {
        //Set only for public variable
        foreach (StarMissionLevel item in this.StarMissionLevels)
        {
            if (item.Level_Mission == level) return item;
        }

        return null;
    }
    public virtual int GetCountAllStarMissionAcquired()
    {
        int count_SM = 0;
        foreach (StarMissionLevel item in this.StarMissionLevels)
        {
            count_SM += item.Count_Star_Acquired;
        }

        return count_SM;
    }
    public virtual void SetCountStarMissionByLevelCurrent(int count)
    {
        //Set only for private variable
        this.SetCountStarMissionByLevel(count, this.Current_Level);
    }

    public virtual void SetCountStarMissionByLevel(int count, int levelSet)
    {
        //Set only for private variable
        StarMissionLevel st = this.GetStarMissionByLevel(levelSet);
        if (st == null) return;
      
        if (st.Count_Star_Acquired >= count) return;

        st.Count_Star_Acquired = count;
    }

    protected virtual void Reset()
    {
        this.LoadComponents();
    }

    protected virtual void LoadComponents()
    {
        this.LoadGameConfigController();
        this.LoadGamePlayConfigUIOverall();
        this.LoadSoundCtrlSO();
        this.LoadShopControllerSO();
        this.LoadArtifactConfigSO();
        this.LoadPlayerSO();
    }

    protected virtual void LoadArtifactConfigSO()
    {
        if (this._ArtifactConfigSO != null) return;

        this._ArtifactConfigSO = Resources.Load<ArtifactConfigSO>("ScriptableObject/SystemConfig/Artifact/ArtifactConfigSO");
    }

    protected virtual void LoadGameConfigController()
    {
        if (this._GameConfigController != null) return;

        this._GameConfigController = Resources.Load<GameConfigController>("ScriptableObject/SystemConfig/GameController/GameConfigController");
    }

    protected virtual void LoadGamePlayConfigUIOverall()
    {
        if (this._GamePlayConfigUIOverall != null) return;

        this._GamePlayConfigUIOverall = Resources.Load<GamePlayConfigUIOverall>("ScriptableObject/SystemConfig/GameController/GamePlayConfigUIOverall");
    }

    protected virtual void LoadSoundCtrlSO()
    {
        if (this._SoundCtrlSO != null) return;

        this._SoundCtrlSO = Resources.Load<SoundCtrlSO>("ScriptableObject/SystemConfig/GameController/Sound/SoundCtrlSO");
    }
    protected virtual void LoadShopControllerSO()
    {
        if (this._ShopControllerSO != null) return;

        this._ShopControllerSO = Resources.Load<ShopControllerSO>("ScriptableObject/SystemConfig/Shop/ShopControllerSO");
    }

    protected virtual void LoadPlayerSO()
    {
        if (this._PlayerSO != null) return;

        this._PlayerSO = Resources.Load<PlayerSO>("ScriptableObject/MovableObjScriptableObject/Character/Player/PlayerSO");
    }
}





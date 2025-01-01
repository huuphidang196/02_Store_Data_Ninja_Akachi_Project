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
        set
        {
            this._Level_Unlock = value;
            if (this._StarMissionLevels.Count >= this._Level_Unlock) return;

            this._StarMissionLevels.Add(new StarMissionLevel(this._Level_Unlock, 0));
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

    [SerializeField] protected PlayerSO _PlayerSO;
    public PlayerSO PlayerSO => this._PlayerSO;

    public virtual StarMissionLevel GetStarMissionByLevel(int level)
    {
        //Set only for public variable
        foreach (StarMissionLevel item in this.StarMissionLevels)
        {
            if (item.Level_Current == level) return item;
        }

        return null;
    }
    public virtual int GetAllStarMissionAcquired()
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
        StarMissionLevel st = this.GetStarMissionByLevel(this.Current_Level);
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
        this.LoadPlayerSO();
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





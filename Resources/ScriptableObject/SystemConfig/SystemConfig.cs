using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SystemConfig", menuName = "ScriptableObject/Configuration/SystemConfig")]
public class SystemConfig : ScriptableObject
{
    [SerializeField] protected List<StarMissionLevel> _StarMissionLevels;
   // public List<StarMissionLevel> StarMissionLevels => this._StarMissionLevels;

    public int Current_Level;

    protected int _Level_Unlock = 1;

    public int Level_Unlock
    {
        get { return this._Level_Unlock; }
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

    [SerializeField] protected PlayerSO _PlayerSO;
    public PlayerSO PlayerSO => this._PlayerSO;

    public virtual StarMissionLevel GetStarMissionByLevel(int level)
    {
        foreach (StarMissionLevel item in this._StarMissionLevels)
        {
            if (item.Level_Current == level) return item;
        }

        return null;
    }

    public virtual void SetCountStarMissionByLevelCurrent(int count)
    {
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

    protected virtual void LoadPlayerSO()
    {
        if (this._PlayerSO != null) return;

        this._PlayerSO = Resources.Load<PlayerSO>("ScriptableObject/MovableObjScriptableObject/Character/Player/PlayerSO");
    }
}





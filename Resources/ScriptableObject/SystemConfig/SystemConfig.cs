using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SystemConfig", menuName = "ScriptableObject/Configuration/SystemConfig")]
public class SystemConfig : ScriptableObject
{
    public int Level_Unlock = 1;
    public int Current_Level;
    public float Total_Golds;
    public float Total_Diamonds;

    [SerializeField] protected GameConfigController _GameConfigController;
    public GameConfigController GameConfigController => this._GameConfigController;

    [SerializeField] protected GamePlayConfigUIOverall _GamePlayConfigUIOverall;
    public GamePlayConfigUIOverall GamePlayConfigUIOverall => this._GamePlayConfigUIOverall;

    [SerializeField] protected PlayerSO _PlayerSO;
    public PlayerSO PlayerSO => this._PlayerSO;

    protected virtual void Reset()
    {
        this.LoadComponents();
    }

    protected virtual void LoadComponents()
    {
        this.LoadGameConfigController();
        this.LoadGamePlayConfigUIOverall();
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

    protected virtual void LoadPlayerSO()
    {
        if (this._PlayerSO != null) return;

        this._PlayerSO = Resources.Load<PlayerSO>("ScriptableObject/MovableObjScriptableObject/Character/Player/PlayerSO");
    }
}





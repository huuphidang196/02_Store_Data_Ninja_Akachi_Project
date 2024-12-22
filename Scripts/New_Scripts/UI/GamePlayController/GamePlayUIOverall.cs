using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayUIOverall : SurMonoBehaviour
{
    [SerializeField] protected GamePlayConfigUIOverall _GamePlayConfigUIOverall;
    public GamePlayConfigUIOverall GamePlayConfigUIOverall => this._GamePlayConfigUIOverall;

    [SerializeField] protected GamePlayUIManager _GamePlayUIManager;
    public GamePlayUIManager GamePlayUIManager => this._GamePlayUIManager;

    [SerializeField] protected GamePlayUIBelow _GamePlayUIBelow;
    public GamePlayUIBelow GamePlayUIBelow => this._GamePlayUIBelow;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadGamePlayConfigUIOverall();
        this.LoadGamePlayUIManager();
        this.LoadGamePlayUIBelow();
    }

    protected virtual void LoadGamePlayUIManager()
    {
        if (this._GamePlayUIManager != null) return;

        this._GamePlayUIManager = GetComponentInChildren<GamePlayUIManager>();
    }

    protected virtual void LoadGamePlayConfigUIOverall()
    {
        if (this._GamePlayConfigUIOverall != null) return;

        this._GamePlayConfigUIOverall = Resources.Load<GamePlayConfigUIOverall>("ScriptableObject/SystemConfig/GameController/GamePlayConfigUIOverall");
    }

    protected virtual void LoadGamePlayUIBelow()
    {
        if (this._GamePlayUIBelow != null) return;

        this._GamePlayUIBelow = GetComponentInChildren<GamePlayUIBelow>();
    }

}

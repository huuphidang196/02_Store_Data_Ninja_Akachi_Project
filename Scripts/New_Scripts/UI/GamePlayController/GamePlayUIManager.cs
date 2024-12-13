using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayUIManager : GamePlayUIOverallAbstract
{
    private static GamePlayUIManager _instance;
    public static GamePlayUIManager Instance => _instance;

    public static Action Event_PauseButton;
    public static Action Event_HideAllUIButton;
    public static Action Event_MusicChanging;

    [SerializeField] protected bool isTogglePanelPause = false;

    public bool IsTogglePanelPause => this.isTogglePanelPause;

    [SerializeField] protected bool isTogglePanelBuyDiamonds = false;

    public bool IsTogglePanelBuyDiamonds => this.isTogglePanelBuyDiamonds;

    [SerializeField] protected bool isHidenUI = false;

    public bool IsHidenUI => this.isHidenUI;

    protected override void Awake()
    {
        base.Awake();

        if (_instance != null) Debug.LogError("Only GamePlayUIManager was allowed existed");

        _instance = this;
    }
    public virtual void TogglePanelPause()
    {
        this.isTogglePanelPause = !this.isTogglePanelPause;

        Event_PauseButton?.Invoke();
    }

    public virtual void IsHidenUIScenePlay()
    {
        this.isHidenUI = !this.isHidenUI;
        Event_HideAllUIButton?.Invoke();
    }

    public virtual void TurnOnUIScenPlay()
    {
        this.isHidenUI = false;
        Event_HideAllUIButton?.Invoke();
    }

    public virtual void TogglePanelBuyDiamonds()
    {
        this.isTogglePanelBuyDiamonds = !this.isTogglePanelBuyDiamonds;
    }

    protected virtual void FixedUpdate()
    {
        this.ProcessEventPlayerRivival();
        this.ProcessEventEndGame();
    }

    protected virtual void ProcessEventPlayerRivival()
    {
        if (GameController.Instance.Rivive_Again == this.isHidenUI) return;

        if (GameController.Instance.Rivive_Again) this.IsHidenUIScenePlay();
        else this.TurnOnUIScenPlay();
    }

    protected virtual void ProcessEventEndGame()
    {
        if (!GameController.Instance.EndGame || GameController.Instance.EndGame == this.isHidenUI) return;

        this.IsHidenUIScenePlay();
    }

    public virtual void ChangeStatusOnOffMusic()
    {
        GameController.Instance.ChangeStatusOnOffMusic();
        Event_MusicChanging?.Invoke();
    }    
}

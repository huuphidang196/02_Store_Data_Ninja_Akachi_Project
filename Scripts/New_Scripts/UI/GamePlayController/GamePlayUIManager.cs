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

    [SerializeField] protected bool isTogglePanelEndGame = false;

    public bool IsTogglePanelEndGame => this.isTogglePanelEndGame;

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
        this.ProcessEventCompletedMission();
        this.ProcessEventEntranceAutoPlayerRunMode();
    }

    protected virtual void ProcessEventEntranceAutoPlayerRunMode()
    {
        if (!GateEntranceAutoRun.Instance.IsEntranceAuto || GateEntranceAutoRun.Instance.IsEntranceAuto == this.isHidenUI) return;

        this.IsHidenUIScenePlay();
    }

    protected virtual void ProcessEventPlayerRivival()
    {
        if (GamePlayController.Instance.Rivive_Again == this.isHidenUI) return;

        if (GamePlayController.Instance.Rivive_Again) this.IsHidenUIScenePlay();
        else this.TurnOnUIScenPlay();
    }

    protected virtual void ProcessEventEndGame()
    {
        if (!GamePlayController.Instance.EndGame || GamePlayController.Instance.EndGame == this.isHidenUI
            || !GateEntranceAutoRun.Instance.IsEntranceAuto) return;

        this.IsHidenUIScenePlay();


    }
    protected virtual void ProcessEventCompletedMission()
    {
        if (GateEntranceAutoRun.Instance.WasCom_Mission == this.GamePlayUIOverall.GamePlayUICenter.UI_Completed_Mission.gameObject.activeInHierarchy) return;
        Invoke(nameof(this.TogglePanelCompletedMission), 1f);
    }

    protected virtual void TogglePanelCompletedMission()
    {
        this.GamePlayUIOverall.GamePlayUICenter.UI_Completed_Mission.gameObject.SetActive(GateEntranceAutoRun.Instance.WasCom_Mission);
    }

    public virtual void ChangeStatusOnOffMusic()
    {
        GamePlayController.Instance.ChangeStatusOnOffMusic();
        Event_MusicChanging?.Invoke();
    }
}

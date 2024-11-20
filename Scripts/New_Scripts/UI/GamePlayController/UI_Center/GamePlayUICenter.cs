using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GamePlayUICenter : GamePlayUIOverallAbstract
{
    [SerializeField] protected Transform _pnl_UI_Pause_Panel;
    public Transform PNL_UI_Pause_Panel => this._pnl_UI_Pause_Panel;

    [SerializeField] protected Transform _pnl_UI_EndGame_Panel;
    public Transform PNL_UI_EndGame_Panel => this._pnl_UI_EndGame_Panel;

    [SerializeField] protected Transform _pnl_UI_BuyDiamonds_Panel;
    public Transform PNL_UI_BuyDiamonds_Panel => this._pnl_UI_BuyDiamonds_Panel;

    [SerializeField] protected SliderTimePlayerHiden _SliderTimePlayerHiden;
    public SliderTimePlayerHiden SliderTimePlayerHiden => this._SliderTimePlayerHiden;

    protected override void Start()
    {
        base.Start();

        GamePlayUIManager.Event_PauseButton += this.ToggleUIPausePanel;
        GamePlayUIManager.Event_HideAllUIButton += this.IsHidenALlChildUIBelow;
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        GamePlayUIManager.Event_PauseButton -= this.ToggleUIPausePanel;
        GamePlayUIManager.Event_HideAllUIButton -= this.IsHidenALlChildUIBelow;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadPanelUIPause();
        this.LoadSliderTimePlayerHiden();
        this.LoadPanelEndGame();
        this.LoadPanelBuyDiamonds();
    }

    protected virtual void LoadPanelUIPause()
    {
        if (this._pnl_UI_Pause_Panel != null) return;

        this._pnl_UI_Pause_Panel = transform.Find("pnlPausePanel").transform;
        this._pnl_UI_Pause_Panel.gameObject.SetActive(false);
    }

    protected virtual void LoadSliderTimePlayerHiden()
    {
        if (this._SliderTimePlayerHiden != null) return;

        this._SliderTimePlayerHiden = transform.GetComponentInChildren<SliderTimePlayerHiden>();
        this._SliderTimePlayerHiden.gameObject.SetActive(false);
    }

    protected virtual void LoadPanelEndGame()
    {
        if (this._pnl_UI_EndGame_Panel != null) return;

        this._pnl_UI_EndGame_Panel = transform.Find("pnlEndGame").transform;
        this._pnl_UI_EndGame_Panel.gameObject.SetActive(false);
    }

    protected virtual void LoadPanelBuyDiamonds()
    {
        if (this._pnl_UI_BuyDiamonds_Panel != null) return;

        this._pnl_UI_BuyDiamonds_Panel = transform.Find("pnlBuyDiamonds").transform;
        this._pnl_UI_BuyDiamonds_Panel.gameObject.SetActive(false);
    }

    protected virtual void FixedUpdate()
    {
        this.ToggleUIEndGamePanel();
        this.ToggleUIBuyDiamondsPanel();
    }

    protected virtual void ToggleUIBuyDiamondsPanel()
    {
        if (GamePlayUIManager.Instance.IsTogglePanelBuyDiamonds == this._pnl_UI_BuyDiamonds_Panel.gameObject.activeInHierarchy) return;

        this._pnl_UI_BuyDiamonds_Panel.gameObject.SetActive(GamePlayUIManager.Instance.IsTogglePanelBuyDiamonds);
    }

    protected virtual void ToggleUIEndGamePanel()
    {
        if (GameController.Instance.EndGame == this._pnl_UI_EndGame_Panel.gameObject.activeInHierarchy) return;

        this._pnl_UI_EndGame_Panel.gameObject.SetActive(GameController.Instance.EndGame);
    }


    protected virtual void Update()
    {
        this.ToggleUISliderTimeHidenPlayer();
    }
    protected virtual void ToggleUIPausePanel()
    {
        if (GamePlayUIManager.Instance.IsTogglePanelPause == this._pnl_UI_Pause_Panel.gameObject.activeInHierarchy) return;

        this._pnl_UI_Pause_Panel.gameObject.SetActive(GamePlayUIManager.Instance.IsTogglePanelPause);
    }

    protected virtual void IsHidenALlChildUIBelow()
    {
        if (GamePlayUIManager.Instance.IsHidenUI != GamePlayUIManager.Instance.IsTogglePanelPause) return;

        if (GamePlayUIManager.Instance.IsHidenUI == transform.GetChild(0).gameObject.activeInHierarchy) return;

        foreach (Transform item in this.transform)
        {
            item.gameObject.SetActive(GamePlayUIManager.Instance.IsHidenUI);
        }

        //Inactive Panel Pause at the same time
        GamePlayUIManager.Instance.TogglePanelPause();

    }

    protected virtual void ToggleUISliderTimeHidenPlayer()
    {
        if (PlayerCtrl.Instance.PlayerDamReceiver.ObjIsDead) this._SliderTimePlayerHiden.gameObject.SetActive(false);

        if (InputManager.Instance.Press_Hiden_Mode == this._SliderTimePlayerHiden.gameObject.activeInHierarchy) return;

        this._SliderTimePlayerHiden.ResetValueSliderBegin();
        this._SliderTimePlayerHiden.gameObject.SetActive(InputManager.Instance.Press_Hiden_Mode);

    }
}

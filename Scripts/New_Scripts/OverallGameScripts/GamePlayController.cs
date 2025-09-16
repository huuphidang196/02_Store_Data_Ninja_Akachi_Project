using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GamePlayController : SystemController
{
    private static GamePlayController m_instance;
    public static GamePlayController Instance => m_instance;

    [Header("GameController")]

    [SerializeField] protected bool _PauseGame;
    public bool PauseGame => _PauseGame;

    [SerializeField] protected bool _EndGame = false;
    public bool EndGame => _EndGame;

    [SerializeField] protected bool _Rivive_Again = false;
    public bool Rivive_Again => _Rivive_Again;

    [SerializeField] protected bool isCompleted_Mission = false;
    public bool IsCompleted_Mission => isCompleted_Mission;

    [SerializeField] protected float _Distance_Active_Enemies;
    public float Distance_Active_Enemies => this._Distance_Active_Enemies;

    [SerializeField] protected int _Order_Buy = 0;

    [SerializeField] protected int _Count_Star_Mission = 0;

    protected override void Awake()
    {
        base.Awake();

        if (m_instance != null) Debug.LogError("Allow only GameController has been exist");

        m_instance = this;
    }

    protected override void ResetValue()
    {
        base.ResetValue();

        this._PauseGame = false;
        this._EndGame = false;
        this._Rivive_Again = false;
        this.isCompleted_Mission = false;
        this._Distance_Active_Enemies = this._SystemConfig.GameConfigController.Distance_Active_Enemies;
        this._Order_Buy = 0;
        this._Count_Star_Mission = 0;
    }

    public override void AddMoneyToSystem(ItemUnit itemUnit)
    {
        base.AddMoneyToSystem(itemUnit);
        if (itemUnit.TypeItem != TypeItemMoney.Star_Mission) return;

        this._Count_Star_Mission++;
        this._SystemConfig.SetCountStarMissionByLevelCurrent(this._Count_Star_Mission);

    }

    public virtual void PauseGamePlay()
    {
        this._PauseGame = true;

        Time.timeScale = 0;
        // Debug.Log("Pause");
    }
    public virtual void ContinueGamePlay()
    {
        this._PauseGame = false;

        Time.timeScale = 1f;
    }

    protected virtual void FixedUpdate()
    {
        this._EndGame = PlayerCtrl.Instance.PlayerObjDead.EndGame;
        this._Rivive_Again = InputManager.Instance.IsRiviving;
    }

    public virtual void IncreseOrderBuy() => this._Order_Buy++;

    public virtual float GetValueMoneyToBuyTwoMoreLives(TypeItemMoney typeItem)
    {
        if (typeItem == TypeItemMoney.NoType) return 0;

        float valueBegin = (typeItem == TypeItemMoney.Gold) ? GamePlayController.Instance.SystemConfig.GameConfigController.Gold_Rivival_Begin.Value :
            GamePlayController.Instance.SystemConfig.GameConfigController.Diamond_Rivival_Begin.Value;

        float value_Compensation = (typeItem == TypeItemMoney.Gold) ? GamePlayController.Instance.SystemConfig.GameConfigController.Compensation_Gold_Rivive :
            GamePlayController.Instance.SystemConfig.GameConfigController.Compensation_Diamond_Rivive;

        return valueBegin + this._Order_Buy * value_Compensation;
    }

    public virtual void RiviveCharacterByMoneyWitTwoLives(TypeItemMoney typeItem)
    {
        if (typeItem == TypeItemMoney.NoType) return;

        float valueNeed = this.GetValueMoneyToBuyTwoMoreLives(typeItem);

        //Check Current money enough to buy
        float currentMoney = (typeItem == TypeItemMoney.Gold) ? this._SystemConfig.Total_Golds : this._SystemConfig.Total_Diamonds;

        if (currentMoney < valueNeed) return;

        if (typeItem == TypeItemMoney.Gold) this._SystemConfig.Total_Golds -= valueNeed;
        else this._SystemConfig.Total_Diamonds -= valueNeed;

        //Rivive Player with 2 lives
        PlayerCtrl.Instance.PlayerObjDead.RiviveCharacterByMoneyWitTwoLives();
    }

    public virtual void ChangeStatusOnOffMusic()
    {
        bool onMusic = SystemController.Sys_Instance.SystemConfig.OnMusic;
        SystemController.Sys_Instance.SystemConfig.OnMusic = !onMusic;
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    protected virtual void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        this.ResetValue();
    }

    protected virtual void ConductSomeActionBeforeLoadScene()
    {
        this.ContinueGamePlay();
        SoundManagerOverall.Instance.BG_Sound_Scene_Play_Mode.IncreseOrderSound();
    }

    public virtual void StartLoadingSceneByNameSceneAfterWatchAds(string nameScene)
    {
        this.ConductSomeActionBeforeLoadScene();

        // Gán global action trước khi show ads
        GoogleAdsManager.Instance.AdmobAdsManager.OnAdInterstitialAdClosedGlobal = () =>
        {
            StartCoroutine(LoadSceneWithWait(nameScene));
        };

        GoogleAdsManager.Instance.AdmobAdsManager.WatchVideoAdsAfterCompletedMissionOrEndGame();
    }

    public override void StartLoadingSceneByOrderScene(int orderScene)
    {
        this.ConductSomeActionBeforeLoadScene();

        // Gán global action trước khi show ads
        GoogleAdsManager.Instance.AdmobAdsManager.OnAdInterstitialAdClosedGlobal = () =>
        {
            base.StartLoadingSceneByOrderScene(orderScene);
        };

        GoogleAdsManager.Instance.AdmobAdsManager.WatchVideoAdsAfterCompletedMissionOrEndGame();
    }
    protected override void ConductActionWhileLoadingNewScene()
    {
        GamePlayUIManager.Instance.GamePlayUIOverall.GamePlayUICenter.UI_Image_BG_Loading.gameObject.SetActive(true);
    }

    public virtual void LoadNextStageAndConductAllActionSet()
    {
        this._SystemConfig.Current_Level += 1;
        SaveManager.Instance.SaveGame();
    }
}

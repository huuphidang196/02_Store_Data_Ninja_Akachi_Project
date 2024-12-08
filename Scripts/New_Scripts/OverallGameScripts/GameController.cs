using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GameController : SystemController
{
    private static GameController m_instance;
    public static GameController Instance => m_instance;

    [Header("GameController")]

    [SerializeField] protected bool _PauseGame;
    public bool PauseGame => _PauseGame;

    [SerializeField] protected bool _EndGame = false;
    public bool EndGame => _EndGame;

    [SerializeField] protected bool _Rivive_Again = false;
    public bool Rivive_Again => _Rivive_Again;

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
        this._Distance_Active_Enemies = this._SystemConfig.GameConfigController.Distance_Active_Enemies;
        this._Order_Buy = 0;
        this._Count_Star_Mission = 0;
    }

    public virtual void AddMoneyToSystem(ItemUnit itemUnit)
    {
        switch (itemUnit.TypeItem)
        {
            case TypeItemMoney.NoType:
                break;
            case TypeItemMoney.Gold:
                this._SystemConfig.Total_Golds += itemUnit.Value;
                break;
            case TypeItemMoney.Diamond:
                this._SystemConfig.Total_Diamonds += itemUnit.Value;
                break;
            case TypeItemMoney.Star_Mission:
                this._Count_Star_Mission++;
                this._SystemConfig.SetCountStarMissionByLevelCurrent(this._Count_Star_Mission);
                break;
            default:
                break;
        }
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

        float valueBegin = (typeItem == TypeItemMoney.Gold) ? GameController.Instance.SystemConfig.GameConfigController.Gold_Rivival_Begin.Value :
            GameController.Instance.SystemConfig.GameConfigController.Diamond_Rivival_Begin.Value;

        float value_Compensation = (typeItem == TypeItemMoney.Gold) ? GameController.Instance.SystemConfig.GameConfigController.Compensation_Gold_Rivive :
            GameController.Instance.SystemConfig.GameConfigController.Compensation_Diamond_Rivive;

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
        bool onMusic = GameController.Instance.SystemConfig.GameConfigController.OnMusic;
        GameController.Instance.SystemConfig.GameConfigController.OnMusic = !onMusic;
    }
}

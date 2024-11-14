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

    [SerializeField] protected float _Distance_Active_Enemies;
    public float Distance_Active_Enemies => this._Distance_Active_Enemies;

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
        this._Distance_Active_Enemies = this._SystemConfig.GameConfigController.Distance_Active_Enemies;
    }

    public virtual void AddMoneyToSystem(ItemDropUnit itemDropUnit)
    {
        switch (itemDropUnit.TypeItem)
        {
            case TypeItem.NoType:
                break;
            case TypeItem.Gold:
                this._SystemConfig.Total_Golds += itemDropUnit.Value_Money;
                break;
            case TypeItem.Diamond:
                this._SystemConfig.Total_Diamonds += itemDropUnit.Value_Money;
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
}

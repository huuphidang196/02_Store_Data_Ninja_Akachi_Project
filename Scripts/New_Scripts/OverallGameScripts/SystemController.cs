using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemController : SurMonoBehaviour
{
    public static int CountScene = 16;

    [SerializeField] protected SystemConfig _SystemConfig;
    public SystemConfig SystemConfig => _SystemConfig;

    private static SystemController m_instance;
    public static SystemController Sys_Instance => m_instance;

    protected override void Awake()
    {
        base.Awake();

        if (m_instance != null) Debug.LogError("Allow only SystemController has been exist");

        m_instance = this;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadSystemConfig();
    }

    protected virtual void LoadSystemConfig()
    {
        if (this._SystemConfig != null) return;
        string namePath = "ScriptableObject/SystemConfig/SystemConfig";
        //Debug.Log(namePath);
        this._SystemConfig = Resources.Load<SystemConfig>(namePath);
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
            default:
                break;
        }
    }

}

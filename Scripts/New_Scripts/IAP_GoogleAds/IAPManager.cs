using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAPManager : SurMonoBehaviour
{
    private static IAPManager _instance;
    public static IAPManager Instance => _instance;
    protected override void Awake()
    {
        base.Awake();

        if (_instance != null) Debug.LogError("Only IAPManager was allowed existed");

        _instance = this;
    }

    public virtual void ProcessBuyDiamonds(ItemDropUnit itemDropUnit)
    {
        this.CheckTransactWasSuccess();
        //if buying progress was successful
        GameController.Instance.AddMoneyToSystem(itemDropUnit.ItemUnit);
    }

    protected virtual bool CheckTransactWasSuccess()
    {
        return true;
    }
}

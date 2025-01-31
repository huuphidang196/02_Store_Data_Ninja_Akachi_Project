using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAPManager : Singleton<IAPManager>
{

    public virtual void ProcessBuyDiamonds(ItemDropUnit itemDropUnit)
    {
        this.CheckTransactWasSuccess();
        //if buying progress was successful
        GamePlayController.Instance.AddMoneyToSystem(itemDropUnit.ItemUnit);
    }

    protected virtual bool CheckTransactWasSuccess()
    {
        return true;
    }
}

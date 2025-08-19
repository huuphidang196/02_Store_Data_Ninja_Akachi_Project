using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAPManager : Singleton<IAPManager>
{
    public virtual void ProcessBuyDiamonds(ItemUnit itemUnit)
    {
        //this.CheckTransactWasSuccess();
        //if buying progress was successful
        SystemController.Sys_Instance.AddMoneyToSystem(itemUnit);
    }

}

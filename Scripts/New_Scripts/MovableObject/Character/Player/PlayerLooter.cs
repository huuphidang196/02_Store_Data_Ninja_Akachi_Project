using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerLooter : CharacterImpactTrigger
{
    protected override string[] GetNameLayerImpactTrigger()
    {
        return new string[] { "ItemLootable" };
    }
    protected override void ProcessImpactTrigger()
    {
        ItemLootableDamReceiver itemLootableDamReceiver = this._parentObj.GetComponentInChildren<ItemLootableDamReceiver>();

        if (itemLootableDamReceiver == null) return;

        this._ObjectCtrl.ObjDamageSender.Send(itemLootableDamReceiver);

        ItemDropUnit itemDropUnit = itemLootableDamReceiver.ItemDropUnit;

        if (itemDropUnit == null) return;
        //Add to the systemcconfig
        GameController.Instance.AddMoneyToSystem(itemDropUnit);
      //  Debug.Log("Money: " + value_Money);
    }


}

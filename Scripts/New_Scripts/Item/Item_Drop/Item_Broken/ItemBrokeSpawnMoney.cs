using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBrokeSpawnMoney : ItemDamReceiver
{
    protected override void OnDead()
    {
        this.SpawnMoneyBag();
        base.OnDead();
    }

    protected virtual void SpawnMoneyBag()
    {
        this.SpawnBoxContainMoney(ItemDropSpawner.Name_Gold_Bag);
    }
    protected virtual void SpawnBoxContainMoney(string nameBox)
    {
        Transform box = ItemDropSpawner.Instance.Spawn(nameBox, this._ObjectCtrl.transform.position + new Vector3(0, 1.5f, 0), Quaternion.identity);

        box.gameObject.name = nameBox;
        box.localScale = Vector3.one;
        box.gameObject.SetActive(true);
    }    
}

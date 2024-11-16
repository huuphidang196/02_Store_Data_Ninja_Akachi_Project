using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGoldBagLootableDamReceiver : ItemLootableDamReceiver
{
    //[Header("ItemGoldBagLootableDamReceiver")]

    //[SerializeField] protected MinMaxPair _Count_Coin_Wave = new MinMaxPair(3f, 5f);

    protected override void SpawnMoneyBag()
    {
        base.SpawnMoneyBag();

        Transform vfx = VFXObjectSpawner.Instance.Spawn(VFXObjectSpawner.VFX_Gold_Coin_Emit, this._ObjectCtrl.transform.position, Quaternion.identity);

        if (vfx == null) return;

        vfx.gameObject.name = VFXObjectSpawner.VFX_Gold_Coin_Emit;
        vfx.localScale = Vector3.one;
        vfx.gameObject.SetActive(true);

        //float count_Coin = Random.Range(this._Count_Coin_Wave.Min, this._Count_Coin_Wave.Max);

        //for (int i = 0; i < count_Coin; i++)
        //{
        //    Transform coin = ItemDropSpawner.Instance.Spawn(ItemDropSpawner.Name_Gold_Coin,
        //        this._ObjectCtrl.transform.position + new Vector3(Random.Range(-0.3f, 0.3f), 1.5f, 0), Quaternion.identity);

        //    coin.gameObject.name = ItemDropSpawner.Name_Gold_Bag;
        //    coin.localScale = Vector3.one;
        //    coin.gameObject.SetActive(true);
        //}
    }
}

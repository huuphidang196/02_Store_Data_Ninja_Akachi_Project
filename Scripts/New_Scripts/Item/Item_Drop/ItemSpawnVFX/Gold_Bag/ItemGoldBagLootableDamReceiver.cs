using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGoldBagLootableDamReceiver : ItemLootableDamReceiver
{
    protected override void SpawnMoneyBag()
    {
        base.SpawnMoneyBag();

        Transform vfx = VFXObjectSpawner.Instance.Spawn(VFXObjectSpawner.VFX_Gold_Coin_Emit, this._ObjectCtrl.transform.position, Quaternion.identity);

        if (vfx == null) return;

        vfx.gameObject.name = VFXObjectSpawner.VFX_Gold_Coin_Emit;
        vfx.localScale = Vector3.one;
        vfx.gameObject.SetActive(true);

    }
}

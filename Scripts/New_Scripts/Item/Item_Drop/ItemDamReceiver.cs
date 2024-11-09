using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDamReceiver : ObjDamageReceiver
{
    protected override void OnDead()
    {
        ItemDropSpawner.Instance.Despawn(this._ObjectCtrl.transform);
        // this.GetValueItemDrop();
    }


}

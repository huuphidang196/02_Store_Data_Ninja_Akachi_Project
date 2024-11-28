using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDamReceiver : ObjDamageReceiver
{
    public ItemDropCtrl ItemDropCtrl => this._ObjectCtrl as ItemDropCtrl;
    protected override void OnDead()
    {
        if (this.ItemDropCtrl.ItemSoundManager == null)
        {
            this.WaitAMomentToPlayMusic();
            return;
        }

        this.ItemDropCtrl.DisableAllObjectExcludeSoundManager();
        //DisableAll Object exclude this
        Invoke(nameof(this.WaitAMomentToPlayMusic), 1f);

        // this.GetValueItemDrop();
    }

    protected virtual void WaitAMomentToPlayMusic()
    {
        ItemDropSpawner.Instance.Despawn(this._ObjectCtrl.transform);
    }
}

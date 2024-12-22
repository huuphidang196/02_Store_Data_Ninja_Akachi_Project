using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSoundManager : ObjSoundRunOnlyOnce
{
    [Header("ItemSoundManager")]
    [SerializeField] protected TypeItemSound _TypeItemSound;

    protected override void Update()
    {
        if (!this.ItemDropCtrl.ItemDamReceiver.ObjIsDead) return;

        base.Update();
    }

    protected override AudioClip GetAudioClipToRun()
    {
      return GameController.Instance.SystemConfig.SoundCtrlSO.SoundItemSO.GetAudioClipByNameTypeItemSound(this._TypeItemSound);
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSoundManager : ObjSoundManager
{
    public ItemDropCtrl ItemDropCtrl => this._ObjectCtrl as ItemDropCtrl;

    [Header("ItemSoundManager")]
    [SerializeField] protected TypeItemSound _TypeItemSound;

    protected override void OnEnable()
    {
        base.OnEnable();

        this._AudioSource.clip = null;
    }
    protected virtual void Update()
    {
        if (!this.ItemDropCtrl.ItemDamReceiver.ObjIsDead) return;

        if (this._AudioSource.clip != null) return;

        if (this._AudioSource.isPlaying) return;

        StartCoroutine(this.PlaySoundItemDisable());
    }

    protected IEnumerator PlaySoundItemDisable()
    {
        while (this._AudioSource.clip == null)
        {
            yield return new WaitForSeconds(0.01f);

            AudioClip audioClip = GameController.Instance.SystemConfig.SoundCtrlSO.SoundItemSO.GetAudioClipByNameTypeItemSound(this._TypeItemSound);

            this.PlaySound(audioClip);
        }


    }
}

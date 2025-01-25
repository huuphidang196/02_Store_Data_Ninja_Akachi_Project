using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjSoundRunOnlyOnce : ObjSoundWasEffectByMusicChanging
{
    public ItemDropCtrl ItemDropCtrl => this._ObjectCtrl as ItemDropCtrl;


    protected override void OnEnable()
    {
        base.OnEnable();

        this._AudioSource.clip = null;
    }
    protected virtual void Update()
    {
        if (this._AudioSource.clip != null) return;

        if (this._AudioSource.isPlaying) return;

        StartCoroutine(this.PlaySoundOnceisable());
    }

    protected IEnumerator PlaySoundOnceisable()
    {
        while (this._AudioSource.clip == null)
        {
            yield return new WaitForSeconds(0.01f);

            AudioClip audioClip = this.GetAudioClipToRun();

            this.PlaySound(audioClip);
        }
    }

    protected abstract AudioClip GetAudioClipToRun();

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjSoundRunOnlyOnce : ObjSoundWasEffectByMusicChanging
{
    [SerializeField] protected bool isActived = false;

    protected override void OnEnable()
    {
        base.OnEnable();

        this.isActived = false;
    }
    protected virtual void Update()
    {
        if (this.isActived) return;

        StartCoroutine(this.PlaySoundOnce());
    }

    protected IEnumerator PlaySoundOnce()
    {
        yield return new WaitForSeconds(0.01f);

        AudioClip audioClip = this.GetAudioClipToRun();

        this.PlaySound(audioClip);
        this.isActived = true;
    }

    protected abstract AudioClip GetAudioClipToRun();

}

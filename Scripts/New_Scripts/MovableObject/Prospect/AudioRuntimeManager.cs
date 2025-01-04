using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioRuntimeManager : ObjSoundWasEffectByMusicChanging
{
    protected override void LoadAudioSource()
    {
        base.LoadAudioSource();

        this._AudioSource.loop = true;
    }

    protected virtual void FixedUpdate()
    {
        if (!this._AudioSource.isPlaying && !GamePlayController.Instance.SystemConfig.GameConfigController.OnMusic) return;

        if (!this.CheckConditionOnMusic()) return;

        if (this._AudioSource.isPlaying) return;

        this.PlaySound(this.GetAudioClipRuntime());
    }

    protected virtual AudioClip GetAudioClipRuntime()
    {
        return null;
    }
}

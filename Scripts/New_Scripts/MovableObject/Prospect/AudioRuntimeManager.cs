using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioRuntimeManager : ObjSoundWasEffectByMusicChanging
{
    [SerializeField] protected bool isSoundLevelMode;
    protected override void LoadAudioSource()
    {
        base.LoadAudioSource();

        this._AudioSource.loop = true;
    }

    protected virtual void FixedUpdate()
    {
        if (this.GetNameSceneCurrent().Contains("Level_") != this.isSoundLevelMode)
        {
            this._AudioSource.Stop();
            return;
        }

        if (!this._AudioSource.isPlaying && !SystemController.Sys_Instance.SystemConfig.OnMusic) return;

        if (!this.CheckConditionOnMusic()) return;

        if (this._AudioSource.isPlaying) return;

        this.PlaySound(this.GetAudioClipRuntime());
    }

    protected virtual AudioClip GetAudioClipRuntime()
    {
        return null;
    }

    protected virtual string GetNameSceneCurrent()
    {
        return SceneManager.GetActiveScene().name;
    }
}

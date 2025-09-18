using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGSoundRunTimeManagerByOnlyTypeSound : AudioRuntimeManager
{
    [SerializeField] protected TypeProspectSound _Type_Sound_Selected_BG;

    protected override void LoadAudioSource()
    {
        base.LoadAudioSource();
        this._AudioSource.volume = 1f;
    }
    protected virtual void Update()
    {
        if (this.GetNameSceneCurrent().Contains("Level_") != this.isSoundLevelMode) return;

        if (!SystemController.Sys_Instance.SystemConfig.OnMusic) return;

        if (this.GetNameSceneCurrent().Contains("Introduce") == (this._AudioSource.clip.name == "Sound_Introduce_Story")) return;

        this._Type_Sound_Selected_BG = this.GetNameSceneCurrent().Contains("Introduce") ? TypeProspectSound.Sound_Introduce_Story : TypeProspectSound.Sound_MainMenu_Adventure;
       
        this._AudioSource.Stop();
        this._AudioSource.clip = this.GetAudioClipRuntime();
        this._AudioSource.Play();

    }
    protected override AudioClip GetAudioClipRuntime()
    {
        return SystemController.Sys_Instance.SystemConfig.SoundCtrlSO.SoundProspectSO.GetAudioClipByNameTypeProspectSound(this._Type_Sound_Selected_BG);
    }

}

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

    protected override AudioClip GetAudioClipRuntime()
    {
        return SystemController.Sys_Instance.SystemConfig.SoundCtrlSO.SoundProspectSO.GetAudioClipByNameTypeProspectSound(this._Type_Sound_Selected_BG);
    }

}

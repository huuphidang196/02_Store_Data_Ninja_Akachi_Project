using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGSoundRunTimeManager : AudioRuntimeManager
{
    [SerializeField] protected List<TypeProspectSound> _List_Sound_BG;

    protected override void LoadAudioSource()
    {
        base.LoadAudioSource();
        this._AudioSource.volume = 0.2f;
    }

    protected override AudioClip GetAudioClipRuntime()
    {
        return this.GetAudioSlipBackGroundByOrder();
    }

    protected virtual AudioClip GetAudioSlipBackGroundByOrder()
    {
        int order = GameController.Instance.SystemConfig.GameConfigController._Order_Music_BG;
        AudioClip audioClip = GameController.Instance.SystemConfig.SoundCtrlSO.SoundProspectSO.GetAudioClipByNameTypeProspectSound(this._List_Sound_BG[order]);

        GameController.Instance.SystemConfig.GameConfigController._Order_Music_BG = (order + 1 >= this._List_Sound_BG.Count) ? 0 : order + 1;
        return audioClip;
    }
}

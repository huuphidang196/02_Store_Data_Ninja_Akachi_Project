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
        this._AudioSource.volume = 0.4f;
    }

    protected override AudioClip GetAudioClipRuntime()
    {
        return this.GetAudioSlipBackGroundByOrder();
    }

    protected virtual AudioClip GetAudioSlipBackGroundByOrder()
    {
        int order = GamePlayController.Instance.SystemConfig.GameConfigController.Order_Music_BG;
        AudioClip audioClip = GamePlayController.Instance.SystemConfig.SoundCtrlSO.SoundProspectSO.GetAudioClipByNameTypeProspectSound(this._List_Sound_BG[order]);

        return audioClip;
    }

    public virtual void IncreseOrderSound()
    {
        int order = GamePlayController.Instance.SystemConfig.GameConfigController.Order_Music_BG;
        GamePlayController.Instance.SystemConfig.GameConfigController.Order_Music_BG = (order + 1 >= this._List_Sound_BG.Count) ? 0 : order + 1;
        this._AudioSource.clip = this.GetAudioSlipBackGroundByOrder();
    }

}

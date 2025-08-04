using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGSoundRunTimeManager : AudioRuntimeManager
{
    [SerializeField] protected List<TypeProspectSound> _List_Sound_BG;
    [SerializeField] protected List<TypeProspectSound> _List_Sound_BG_Final_Scene;

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
        int order = (GamePlayController.Instance.SystemConfig.Current_Level != 16) ? GamePlayController.Instance.SystemConfig.GameConfigController.Order_Music_BG : 0;
        AudioClip audioClip = GamePlayController.Instance.SystemConfig.Current_Level != 16 ? GamePlayController.Instance.SystemConfig.SoundCtrlSO.SoundProspectSO.GetAudioClipByNameTypeProspectSound(this._List_Sound_BG[order])
           : GamePlayController.Instance.SystemConfig.SoundCtrlSO.SoundProspectSO.GetAudioClipByNameTypeProspectSound(this._List_Sound_BG_Final_Scene[order]);

        return audioClip;
    }

    public virtual void IncreseOrderSound()
    {
        if (GamePlayController.Instance.SystemConfig.Current_Level != 16)
        {
            int order = GamePlayController.Instance.SystemConfig.GameConfigController.Order_Music_BG;
            GamePlayController.Instance.SystemConfig.GameConfigController.Order_Music_BG = (order + 1 >= this._List_Sound_BG.Count) ? 0 : order + 1;
        }

        this._AudioSource.clip = this.GetAudioSlipBackGroundByOrder();
    }


}

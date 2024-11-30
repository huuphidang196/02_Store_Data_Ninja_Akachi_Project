using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXSoundManager : ObjSoundWasEffectByMusicChanging
{
    [Header("VFXSoundManager")]
    [SerializeField] protected TypeVFXSound _TypeVFXSound;

    protected override void OnEnable()
    {
        base.OnEnable();

        if (GameController.Instance == null) return;

        this.GetClipAndRun();
    }

    protected virtual void GetClipAndRun()
    {
        if (!this.CheckConditionOnMusic()) return;

        if (this._AudioSource.isPlaying) return;

        AudioClip audioClip = GameController.Instance.SystemConfig.SoundCtrlSO.SoundVFXSO.GetAudioClipByNameTypeVFXSound(this._TypeVFXSound);
        //Debug.Log("name: " + audioClip.name);
        this.PlaySound(audioClip);

    }
}

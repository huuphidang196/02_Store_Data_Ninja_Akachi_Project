using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXSoundManager : ObjSoundManager
{
    [Header("ItemSoundManager")]
    [SerializeField] protected TypeVFXSound _TypeVFXSound;

    protected override void OnEnable()
    {
        base.OnEnable();

        this.GetClipAndRun();
    }

    protected override void Start()
    {
        base.Start();

        Invoke(nameof(this.GetClipAndRun), 0.1f);
    }
    protected virtual void GetClipAndRun()
    {
        if (GameController.Instance == null) return;

        if (this._AudioSource.isPlaying) return;

        AudioClip audioClip = GameController.Instance.SystemConfig.SoundCtrlSO.SoundVFXSO.GetAudioClipByNameTypeVFXSound(this._TypeVFXSound);
        //Debug.Log("name: " + audioClip.name);
        this.PlaySound(audioClip);
    }
}

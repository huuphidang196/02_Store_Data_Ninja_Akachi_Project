using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSoundManager : ObjSoundWasEffectByMusicChanging
{
    [Header("WeaponSoundManager")]
    [SerializeField] protected TypeWeaponSound _TypeWeaponSound;

    protected override void OnEnable()
    {
        base.OnEnable();

        this._AudioSource.clip = null;
    }

    protected virtual void Update()
    {
        if (this._AudioSource.clip != null) return;

        if (this._AudioSource.isPlaying) return;

        this.PlaySoundWeapon();
    }

    protected virtual void PlaySoundWeapon()
    {
        AudioClip audioClip = GameController.Instance.SystemConfig.SoundCtrlSO.SoundWeaponSO.GetAudioClipByNameTypeWeaponSound(this._TypeWeaponSound);

        this.PlaySound(audioClip);
    }
}
using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class ObjSoundManager : ObjectAbstract
{
    [Header("ObjSoundManager")]
    [SerializeField] protected AudioSource _AudioSource;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadAudioSource();
    }

    protected virtual void LoadAudioSource()
    {
        if (this._AudioSource != null) return;

        this._AudioSource = GetComponent<AudioSource>();
    }

    protected virtual void PlaySound(AudioClip clip)
    {
        if (clip == null) return;

        this._AudioSource.clip = clip;
        this._AudioSource.Play();
    }

}

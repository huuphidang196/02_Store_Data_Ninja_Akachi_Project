using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCtrlSOAbstract : ScriptableObject
{
    [SerializeField] protected SoundCtrlSO _SoundCtrlSO;
    public SoundCtrlSO SoundCtrlSO => this._SoundCtrlSO;

    public AudioClip[] Sound_Clips;

    protected virtual void Reset()
    {
        this.LoadSoundCtrlSO();
    }

    protected virtual void LoadSoundCtrlSO()
    {
        if (this._SoundCtrlSO != null) return;

        this._SoundCtrlSO = Resources.Load<SoundCtrlSO>("ScriptableObject/SystemConfig/GameController/Sound/SoundCtrlSO");
    }

    public virtual AudioClip GetAudioClipByName(string nameClip)
    {
        foreach (AudioClip audi in this.Sound_Clips)
        {
            if (audi.name.Contains(nameClip)) return audi;
        }

        return null;
    }
}

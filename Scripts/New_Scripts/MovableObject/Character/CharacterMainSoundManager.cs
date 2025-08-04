using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterMainSoundManager : ObjSoundWasEffectByMusicChanging
{
    protected abstract void PlayeSoundWithNameAction(string nameAction);
 
    protected override void PlaySound(AudioClip clip)
    {
        if (clip == null) return;

        if (this._AudioSource.isPlaying && clip.name == this._AudioSource.clip.name) return; // Tránh chồng âm

        if (!this.CheckOrderSound(clip)) return;

        base.PlaySound(clip);
    }

    protected virtual bool CheckOrderSound(AudioClip clip)
    {    
        return true;
    }

}

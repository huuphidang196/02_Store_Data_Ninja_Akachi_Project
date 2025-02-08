using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjSoundWasEffectByMusicChanging : ObjSoundManager
{
    protected override void PlaySound(AudioClip clip)
    {
        if (!this.CheckConditionOnMusic()) return;

        base.PlaySound(clip);
    }

    protected virtual bool CheckConditionOnMusic()
    {
        if (!SystemController.Sys_Instance.SystemConfig.OnMusic)
        {
            this._AudioSource.Stop();
            return false;
        }

        return true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXSoundManager : ObjSoundRunOnlyOnce
{
    [Header("VFXSoundManager")]
    [SerializeField] protected TypeVFXSound _TypeVFXSound;
    
    protected override AudioClip GetAudioClipToRun()
    {
        return GamePlayController.Instance.SystemConfig.SoundCtrlSO.SoundVFXSO.GetAudioClipByNameTypeVFXSound(this._TypeVFXSound);
    }
}

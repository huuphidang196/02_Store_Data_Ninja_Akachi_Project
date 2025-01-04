using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXFireBurning : AudioRuntimeManager
{
    [Header("VFXFireBurning")]
    [SerializeField] protected TypeVFXSound _TypeVFXSound;

    protected override AudioClip GetAudioClipRuntime()
    {
        return GamePlayController.Instance.SystemConfig.SoundCtrlSO.SoundVFXSO.GetAudioClipByNameTypeVFXSound(this._TypeVFXSound);
    }

}

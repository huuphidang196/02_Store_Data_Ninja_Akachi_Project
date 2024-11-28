using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SoundVFXSO", menuName = "ScriptableObject/Sound/SoundCtrlSO/SoundVFXSO", order = 2)]
public class SoundVFXSO : SoundCtrlSOAbstract
{
    public virtual AudioClip GetAudioClipByNameTypeVFXSound(TypeVFXSound typeVFXSound)
    {
        return this.GetAudioClipByName(typeVFXSound.ToString());
    }

}

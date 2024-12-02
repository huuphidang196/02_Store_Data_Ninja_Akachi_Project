using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SoundWeaponSO", menuName = "ScriptableObject/Sound/SoundCtrlSO/SoundWeaponSO", order = 5)]
public class SoundWeaponSO : SoundCtrlSOAbstract
{
    public virtual AudioClip GetAudioClipByNameTypeWeaponSound(TypeWeaponSound typeWeaponSound)
    {
        return this.GetAudioClipByName(typeWeaponSound.ToString());
    }
}


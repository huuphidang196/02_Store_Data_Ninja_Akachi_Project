using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SoundProspectSO", menuName = "ScriptableObject/Sound/SoundCtrlSO/SoundProspectSO", order = 3)]

public class SoundProspectSO : SoundCtrlSOAbstract
{
    public virtual AudioClip GetAudioClipByNameTypeProspectSound(TypeProspectSound typeProspectSound)
    {
        return this.GetAudioClipByName(typeProspectSound.ToString());
    }

}

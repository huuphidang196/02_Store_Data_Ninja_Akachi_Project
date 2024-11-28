using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SoundItemSO", menuName = "ScriptableObject/Sound/SoundCtrlSO/SoundItemSO", order = 1)]
public class SoundItemSO : SoundCtrlSOAbstract
{
    public virtual AudioClip GetAudioClipByNameTypeItemSound(TypeItemSound typeItemSound)
    {
        return this.GetAudioClipByName(typeItemSound.ToString());
    }
}

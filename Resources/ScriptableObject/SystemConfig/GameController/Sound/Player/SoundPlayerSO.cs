using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SoundPlayerSO", menuName = "ScriptableObject/Sound/SoundCtrlSO/SoundPlayerSO", order = 0)]
public class SoundPlayerSO : SoundCtrlSOAbstract
{
    public virtual AudioClip GetAudioClipByNameAction(string nameAction)
    {
        return this.GetAudioClipByName(nameAction);
    }
}

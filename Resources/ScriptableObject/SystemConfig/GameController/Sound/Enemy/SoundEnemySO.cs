using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SoundEnemySO", menuName = "ScriptableObject/Sound/SoundCtrlSO/SoundEnemySO", order = 4)]
public class SoundEnemySO : SoundCtrlSOAbstract
{
    public virtual AudioClip GetAudioClipByNameAction(string nameAction)
    {
        return this.GetAudioClipByName(nameAction);
    }
}

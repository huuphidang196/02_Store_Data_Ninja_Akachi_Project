using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SoundPlayerSO", menuName = "ScriptableObject/Sound/SoundManagerSO/SoundPlayerSO", order = 0)]
public class SoundPlayerSO : ScriptableObject
{
    public AudioClip[] Sound_Clips_Player;

    public virtual AudioClip GetAudioClipByNameAction(string nameAction)
    {
        foreach (AudioClip audi in this.Sound_Clips_Player)
        {
            if (audi.name.Contains(nameAction)) return audi;
        }

        return null;
    }    
}

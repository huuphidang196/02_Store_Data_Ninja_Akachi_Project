using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SoundManagerSO", menuName = "ScriptableObject/Sound/SoundManagerSO", order = 0)]
public class SoundManagerSO : SystemConfigCtrl
{
    [SerializeField] protected SoundPlayerSO _SoundPlayerSO;
    public SoundPlayerSO SoundPlayerSO => this._SoundPlayerSO;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSoundPlayerSO();
    }

    protected virtual void LoadSoundPlayerSO()
    {
        if (this._SoundPlayerSO != null) return;

        this._SoundPlayerSO = Resources.Load<SoundPlayerSO>("ScriptableObject/SystemConfig/GameController/Sound/Player/SoundPlayerSO");
    }
}

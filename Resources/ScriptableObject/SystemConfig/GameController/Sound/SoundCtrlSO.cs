using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "SoundManagerSO", menuName = "ScriptableObject/Sound/SoundCtrlSO", order = 0)]
public class SoundCtrlSO : SystemConfigCtrl
{
    [SerializeField] protected SoundPlayerSO _SoundPlayerSO;
    public SoundPlayerSO SoundPlayerSO => this._SoundPlayerSO;

    [SerializeField] protected SoundItemSO _SoundItemSO;
    public SoundItemSO SoundItemSO => this._SoundItemSO;

    [SerializeField] protected SoundVFXSO _SoundVFXSO;
    public SoundVFXSO SoundVFXSO => this._SoundVFXSO;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSoundPlayerSO();
        this.LoadSoundItemSO();
        this.LoadSoundVFXSO();
    }
 

    protected virtual void LoadSoundPlayerSO()
    {
        if (this._SoundPlayerSO != null) return;

        this._SoundPlayerSO = Resources.Load<SoundPlayerSO>("ScriptableObject/SystemConfig/GameController/Sound/Player/SoundPlayerSO");
    }
    protected virtual void LoadSoundItemSO()
    {
        if (this._SoundItemSO != null) return;

        this._SoundItemSO = Resources.Load<SoundItemSO>("ScriptableObject/SystemConfig/GameController/Sound/Item/SoundItemSO");
    }

    protected virtual void LoadSoundVFXSO()
    {
        if (this._SoundVFXSO != null) return;

        this._SoundVFXSO = Resources.Load<SoundVFXSO>("ScriptableObject/SystemConfig/GameController/Sound/VFX/SoundVFXSO");
    }
}

[Serializable]
public class ObjectUnit
{
    public TypeObject TypeObject;//for path load name folder

}
[Serializable]
public class ItemSoundUnit : ObjectUnit
{
    public TypeItemSound TypeItemSound;
}
public enum TypeObject
{
    NoType = 0,

    Character = 1,

    Item = 2,

    Weapon = 3,

    VFX = 4,
}

public enum TypeCharacter
{
    NoType = 0,

    Player = 1,

    Enemy = 2,
}
public enum TypeItemSound
{
    NoType = 0,

    Sound_Gold_Bag_Diamonds_Bag = 1,
    Sound_Wood_Box = 2,
    Sound_Jar_Broke = 3,
}

public enum TypeVFXSound
{
    NoType = 0,

    Sound_VFX_Boom_Explosion = 1,
    Sound_VFX_Ground_Emit = 2,
    Sound_VFX_Ignite_Fire = 3,
    Sound_VFX_Fire_Burning = 4,
}

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

    [SerializeField] protected SoundProspectSO _SoundProspectSO;
    public SoundProspectSO SoundProspectSO => this._SoundProspectSO;

    [SerializeField] protected SoundEnemySO _SoundEnemySO;
    public SoundEnemySO SoundEnemySO => this._SoundEnemySO;

    [SerializeField] protected SoundWeaponSO _SoundWeaponSO;
    public SoundWeaponSO SoundWeaponSO => this._SoundWeaponSO;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadSoundPlayerSO();
        this.LoadSoundItemSO();
        this.LoadSoundVFXSO();
        this.LoadSoundProspectSO();
        this.LoadSoundEnemySO();
        this.LoadSoundWeaponSO();
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
    protected virtual void LoadSoundProspectSO()
    {
        if (this._SoundProspectSO != null) return;

        this._SoundProspectSO = Resources.Load<SoundProspectSO>("ScriptableObject/SystemConfig/GameController/Sound/Prospect/SoundProspectSO");
    }
    protected virtual void LoadSoundEnemySO()
    {
        if (this._SoundEnemySO != null) return;

        this._SoundEnemySO = Resources.Load<SoundEnemySO>("ScriptableObject/SystemConfig/GameController/Sound/Enemy/SoundEnemySO");
    }
    protected virtual void LoadSoundWeaponSO()
    {
        if (this._SoundWeaponSO != null) return;

        this._SoundWeaponSO = Resources.Load<SoundWeaponSO>("ScriptableObject/SystemConfig/GameController/Sound/Weapon/SoundWeaponSO");
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

public enum TypeActionEnemy
{
    NoType = 0,

    Detect = 1,
    Attack = 2,
    Dead = 3,
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
    Sound_VFX_Blood = 5,
}
public enum TypeProspectSound
{
    NoType = 0,

    Sound_BackGround_01 = 101,
    Sound_BackGround_02 = 102,
    Sound_BackGround_03 = 103,

    Sound_Ring_The_Bell = 801,
}

public enum TypeWeaponSound
{
    NoType = 0,

    Sound_Weapon_Bullet_Enemy = 1,
}

//public enum TypeActionEnemy
//{
//    NoType = 0,

//    //Shooter
//    Sound_Shooter_Detect = 1,
//    Sound_Shooter_Chamber_Shooting = 2,
//    Sound_Shooter_Dead = 3,

//    //Sword
//    Sound_Sword_Detect = 4,
//    Sound_Sword_Attack = 5,
//    Sound_Sword_Dead = 6,

//    //Spear
//    Sound_Spear_Shouting = 7,
//    Sound_Spear_Attack = 8,
//    Sound_Spear_Dead = 9,

//    Sound_Enemy_Hurt = 10,
//}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCharacterSpawner : Spawner
{
    private static WeaponCharacterSpawner _instance;
    public static WeaponCharacterSpawner Instance => _instance;

    public static string Name_Shuriken = "Shuriken_Weapon";

    public static string Name_Bullet_Enemy_Shooter= "Bullet_Enemy_Shooter";

    public static string VFX_Slash_Attack = "Weapon_VFX_Slash_Attack";
    protected override void Awake()
    {
        base.Awake();

        if (_instance != null) Debug.LogError("Only 1 WeaponCharacterSpawner was allowed exist");

        _instance = this;
    }


}

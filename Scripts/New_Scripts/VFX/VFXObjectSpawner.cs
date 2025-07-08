using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXObjectSpawner : Spawner
{
    private static VFXObjectSpawner m_instance;
    public static VFXObjectSpawner Instance => m_instance;
    
    public static string VFX_Boom_Explosion = "VFX_Boom_Explosion";
    public static string VFX_Gold_Coin_Emit = "VFX_Gold_Coin_Emit";
    public static string VFX_Ignite_Fire = "VFX_Ignite_Fire";
    public static string VFX_Blood_Fly = "VFX_Blood_Fly";
    public static string VFX_Ground_Emit = "VFX_Ground_Emit";
    public static string VFX_WoodBox_Emit = "VFX_WoodBox_Emit";
    public static string VFX_Shadow_Step = "VFX_Shadow_Step";
    public static string VFX_Drop_Attack = "VFX_Drop_Attack";
    protected override void Awake()
    {
        base.Awake();

        if (m_instance != null) Debug.LogError("Allow only VFXObjectSpawner has been exist");

        m_instance = this;
    }
 
}

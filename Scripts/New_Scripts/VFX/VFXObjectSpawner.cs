using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXObjectSpawner : Spawner
{
    private static VFXObjectSpawner m_instance;
    public static VFXObjectSpawner Instance => m_instance;

    public static string VFX_Boom_Explosion = "Boom_Explosion";

    protected override void Awake()
    {
        base.Awake();

        if (m_instance != null) Debug.LogError("Allow only VFXObjectSpawner has been exist");

        m_instance = this;
    }
}

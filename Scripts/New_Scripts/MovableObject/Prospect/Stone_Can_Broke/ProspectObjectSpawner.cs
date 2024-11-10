using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProspectObjectSpawner : Spawner
{
    private static ProspectObjectSpawner _instance;
    public static ProspectObjectSpawner Instance => _instance;

    protected override void Awake()
    {
        base.Awake();

        if (_instance != null) Debug.LogError("Only ProspectObjectSpawner was allowed existed");

        _instance = this;
    }

}

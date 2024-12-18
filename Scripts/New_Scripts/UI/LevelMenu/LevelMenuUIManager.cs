using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMenuUIManager : LevelMenuUIAbstract
{
    private static LevelMenuUIManager _instance;
    public static LevelMenuUIManager Instance => _instance;

    protected override void Awake()
    {
        base.Awake();

        if (_instance != null) Debug.LogError("Only LevelMenuUIManager was allowed existed");

        _instance = this;
    }
}

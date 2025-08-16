using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalGamePlayController : GamePlayController
{
    private static FinalGamePlayController m_Final_instance;
    public static FinalGamePlayController Final_Instance => m_Final_instance;

    [Header("FinalGamePlayController")]

    [SerializeField] protected bool isFinalScene = false;
    public bool IsFinalScene => isFinalScene;

    protected override void Awake()
    {
        base.Awake();

        if (m_Final_instance != null) Debug.LogError("Allow only GameController has been exist");

        m_Final_instance = this;
    }
    protected override void Start()
    {
        base.Start();

        this.isFinalScene = this._SystemConfig.Current_Level == 16;
    }

    public virtual void ProcessAllEventSystemAfterEndGame()
    {
        //Set Stars
        this._SystemConfig.SetCountStarMissionByLevelCurrent(3);

        // Set Level Unlock
        this._SystemConfig.SetLevelUnlock(16);

        //Back Scene
        GateEntranceAutoRun.Instance.SetCompletedMissionOnLastLevel();

        SaveManager.Instance.SaveGame();

        this.StartLoadingSceneByNameSceneAfterWatchAds("LevelMenu");

    }
}


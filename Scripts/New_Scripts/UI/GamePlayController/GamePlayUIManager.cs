using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayUIManager : GamePlayUIOverallAbstract
{
    private static GamePlayUIManager _instance;
    public static GamePlayUIManager Instance => _instance;

    [SerializeField] protected bool isToggle = false;

    public bool IsToggle => this.isToggle;


    [SerializeField] protected bool isHidenUI = false;

    public bool IsHidenUI => this.isHidenUI;
    protected override void Awake()
    {
        base.Awake();

        if (_instance != null) Debug.LogError("Only GamePlayUIManager was allowed existed");

        _instance = this;
    }
    public virtual void TogglePanelPause()
    {
        this.isToggle = !this.isToggle;
       
    }

    public virtual void IsHidenUIScenePlay()
    {
        this.isHidenUI = !this.isHidenUI;

    }

    public virtual void TurnOnUIScenPlay() => this.isHidenUI = false;
}

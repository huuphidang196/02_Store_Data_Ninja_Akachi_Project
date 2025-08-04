using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCtrl : EnemyCtrl
{
    private static BossCtrl _instance;
    public static BossCtrl Instance => _instance;

    public BossAnimation BossAnimation => this._CharacterAnimation as BossAnimation;
    public BossCheckContactEnviroment BossCheckContactEnviroment => this._CharacterCheckContactEnviroment as BossCheckContactEnviroment;
    public BossEnemyMovement BossEnemyMovement => this._MovableObj_Movement as BossEnemyMovement;

    public BossEnemyDamReceiver BossEnemyDamReceiver => this.EnemyDamReceiver as BossEnemyDamReceiver;

    [Header("BossCtrl")]

    [SerializeField] protected InputManagerBoss _InputManagerBoss;
    public InputManagerBoss InputManagerBoss => this._InputManagerBoss;

    [SerializeField] protected BossSoundManager _BossSoundManager;
    public BossSoundManager BossSoundManager => this._BossSoundManager;


    protected override void Awake()
    {
        base.Awake();

        if (_instance != null) Debug.LogError("Only One BossCtrl is allowed to exist");

        _instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadInputManagerBoss();
        this.LoadBossSoundManager();
    }

    protected virtual void LoadBossSoundManager()
    {
        if (this._BossSoundManager != null) return;

        this._BossSoundManager = GetComponentInChildren<BossSoundManager>();
    }

    protected virtual void LoadInputManagerBoss()
    {
        if (this._InputManagerBoss != null) return;

        this._InputManagerBoss = GetComponentInChildren<InputManagerBoss>();
    }
}

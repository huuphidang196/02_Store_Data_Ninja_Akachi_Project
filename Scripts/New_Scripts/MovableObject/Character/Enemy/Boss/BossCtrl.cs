using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCtrl : EnemyCtrl
{
    public BossAnimation BossAnimation => this._CharacterAnimation as BossAnimation;
    public BossCheckContactEnviroment BossCheckContactEnviroment => this._CharacterCheckContactEnviroment as BossCheckContactEnviroment;
    public BossEnemyMovement BossEnemyMovement => this._MovableObj_Movement as BossEnemyMovement;

    [Header("BossCtrl")]

    [SerializeField] protected InputManagerBoss _InputManagerBoss;
    public InputManagerBoss InputManagerBoss => this._InputManagerBoss;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadInputManagerBoss();
    }

    protected virtual void LoadInputManagerBoss()
    {
        if (this._InputManagerBoss != null) return;

        this._InputManagerBoss = GetComponentInChildren<InputManagerBoss>();
    }
}

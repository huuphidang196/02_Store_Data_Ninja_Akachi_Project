using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : CharacterCtrl
{
    private static PlayerCtrl _instance;
    public static PlayerCtrl Instance => _instance;

    public PlayerDamReceiver PlayerDamReceiver => this._ObjDamageReceiver as PlayerDamReceiver;
    public PlayerCheckContactEnviroment PlayerCheckContactEnviroment => this._CharacterCheckContactEnviroment as PlayerCheckContactEnviroment;

    public PlayerMovement PlayerMovement => this._MovableObj_Movement as PlayerMovement;

    public PlayerAnimation PlayerAnimation => this._CharacterAnimation as PlayerAnimation;

    public PlayerSO PlayerSO => this._MObjScriptableObject as PlayerSO;

    public PlayerVFXManager PlayerVFXManager => this.CharacterVFXManager as PlayerVFXManager;

    [Header("Player Ctrl")]
    [SerializeField] protected PlayerObjDead _PlayerObjDead;
    public PlayerObjDead PlayerObjDead => _PlayerObjDead;

    [SerializeField] protected PlayerAttack _PlayerAttack;
    public PlayerAttack PlayerAttack => _PlayerAttack;

    [SerializeField] protected PlayerLooter _PlayerLooter;
    public PlayerLooter PlayerLooter => _PlayerLooter;

    [SerializeField] protected PlayerSoundManager _PlayerSoundManager;
    public PlayerSoundManager PlayerSoundManager => this._PlayerSoundManager;

    protected override void Awake()
    {
        base.Awake();
        if (_instance != null) Debug.LogError("Only One PlayerLooter is allowed to exist");

        _instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadPlayerObjDead();
        this.LoadPlayerAttack();
        this.LoadPlayerLooter();
        this.LoadPlayerSoundManager();
    }
    protected virtual void LoadPlayerObjDead()
    {
        if (this._PlayerObjDead != null) return;

        this._PlayerObjDead = GetComponentInChildren<PlayerObjDead>();
    }

    protected virtual void LoadPlayerAttack()
    {
        if (this._PlayerAttack != null) return;

        this._PlayerAttack = GetComponentInChildren<PlayerAttack>();
    }
    protected virtual void LoadPlayerLooter()
    {
        if (this._PlayerLooter != null) return;

        this._PlayerLooter = GetComponentInChildren<PlayerLooter>();
    }
    protected virtual void LoadPlayerSoundManager()
    {
        if (this._PlayerSoundManager != null) return;

        this._PlayerSoundManager = GetComponentInChildren<PlayerSoundManager>();
    }

}

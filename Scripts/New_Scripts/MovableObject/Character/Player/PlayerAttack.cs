using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : PlayerAbstract
{
    [Header("PlayerAttack")]

    [SerializeField] protected PlayerImpact _PlayerImpact;
    public PlayerImpact PlayerImpact => this._PlayerImpact;

    [SerializeField] protected ObjDamageSender _ObjDamSender;
    public ObjDamageSender ObjDamageSender => this._ObjDamSender;

    [SerializeField] protected Transform _Pos_Spawn_Shuriken;

    [SerializeField] protected bool isThrowing;
    [SerializeField] protected float _Time_Delay = 0.25f;
    [SerializeField] protected float _Timer = 0;

    protected override void ResetValue()
    {
        base.ResetValue();

        this.isThrowing = false;
        this._Timer = 0;
        this._Time_Delay = 0.25f;
    }

    #region OnEnable_Disable
    protected override void OnEnable()
    {
        base.OnEnable();
        InputManager.PressAttackThrowButton_Event += this.PerformAttackThrowShuriken;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        InputManager.PressAttackThrowButton_Event -= this.PerformAttackThrowShuriken;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadPlayerImpact();
        this.LoadObjDamSender();
        this.LoadPositionSpawnShuriken();
    }

    protected virtual void LoadPlayerImpact()
    {
        if (this._PlayerImpact != null) return;

        this._PlayerImpact = GetComponentInChildren<PlayerImpact>();
    }

    protected virtual void LoadObjDamSender()
    {
        if (this._ObjDamSender != null) return;

        this._ObjDamSender = GetComponentInChildren<ObjDamageSender>();
    }

    protected virtual void LoadPositionSpawnShuriken()
    {
        if (this._Pos_Spawn_Shuriken != null) return;

        this._Pos_Spawn_Shuriken = transform.Find("Pos_Throw_Shuriken");
    }

    #endregion OnEnable_Disable

    protected virtual void Update()
    {
        if (!this._PlayerCtrl.PlayerMovement.IsStunned)
        {
            this.PerformAttackDashing();       
        }

        if (!this.isThrowing) return;

        this._Timer += Time.deltaTime;

        if (this._Timer < this._Time_Delay) return;

        //Change pos Spawn
        transform.localScale = (this._PlayerCtrl.PlayerMovement.IsWallSliding) ?
            this._PlayerCtrl.PlayerAnimation.transform.localScale : new Vector3(1, transform.localScale.y, 0);

        this.ActionThrowShuriken();
        
        this.ResetValue();
    }

    protected virtual void PerformAttackDashing()
    {
        if (this._PlayerCtrl.PlayerMovement.IsDashing == this._PlayerImpact.gameObject.activeInHierarchy) return;

        this._PlayerImpact.gameObject.SetActive(this._PlayerCtrl.PlayerMovement.IsDashing);
    }

    public virtual void PerformAttackThrowShuriken()
    {
        //if (this._PlayerCtrl.PlayerMovement.IsStunned) return;

        if (this._PlayerCtrl.PlayerDamReceiver.ObjIsDead) return;

        this.isThrowing = true;
    }

    protected virtual void ActionThrowShuriken()
    {
        Transform shurikenSpawned = WeaponCharacterSpawner.Instance.Spawn(WeaponCharacterSpawner.Name_Shuriken, this._Pos_Spawn_Shuriken.position, Quaternion.identity);
        shurikenSpawned.position = this._Pos_Spawn_Shuriken.position;
        //Set Direction fly
        ShurikenCtrl shurikenCtrl = shurikenSpawned.GetComponent<ShurikenCtrl>();

        Vector3 dir = this._PlayerCtrl.PlayerMovement.IsWallSliding ? -1f * this._PlayerCtrl.transform.localScale : this._PlayerCtrl.transform.localScale;
        shurikenCtrl.WeaponCharacterMovement.SetDirectionFly(dir);

        shurikenSpawned.localScale = Vector3.one;
        shurikenSpawned.name = WeaponCharacterSpawner.Name_Shuriken;

        shurikenSpawned.gameObject.SetActive(true);
    }
}

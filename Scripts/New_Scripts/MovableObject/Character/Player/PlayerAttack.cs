using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : PlayerAbstract
{
    [Header("PlayerAttack")]

    [SerializeField] protected PlayerImpact _PlayerImpact;
    public PlayerImpact PlayerImpact => this._PlayerImpact;

    [SerializeField] protected ObjDamSenderInfinity _ObjDamSenderInfinity;
    public ObjDamSenderInfinity ObjDamSenderInfinity => this._ObjDamSenderInfinity;

    [SerializeField] protected Transform _Pos_Spawn_Shuriken;

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
        this.LoadObjDamSenderInfinity();
        this.LoadPositionSpawnShuriken();
    }
    protected virtual void LoadPlayerImpact()
    {
        if (this._PlayerImpact != null) return;

        this._PlayerImpact = GetComponentInChildren<PlayerImpact>();
    }

    protected virtual void LoadObjDamSenderInfinity()
    {
        if (this._ObjDamSenderInfinity != null) return;

        this._ObjDamSenderInfinity = GetComponentInChildren<ObjDamSenderInfinity>();
    }

    protected virtual void LoadPositionSpawnShuriken()
    {
        if (this._Pos_Spawn_Shuriken != null) return;

        this._Pos_Spawn_Shuriken = transform.Find("Pos_Throw_Shuriken");
    }

    #endregion OnEnable_Disable

    protected virtual void Update()
    {
        //Change pos Spawn
        transform.localScale = (this._PlayerCtrl.PlayerMovement.IsWallSliding) ?
            this._PlayerCtrl.PlayerAnimation.transform.localScale : new Vector3(1, transform.localScale.y, 0);

        this.PerformAttackDashing();

    }

    protected virtual void PerformAttackDashing()
    {
        if (this._PlayerCtrl.PlayerMovement.IsDashing == this._PlayerImpact.gameObject.activeInHierarchy) return;

        this._PlayerImpact.gameObject.SetActive(this._PlayerCtrl.PlayerMovement.IsDashing);
    }

    public virtual void PerformAttackThrowShuriken()
    {
        float timeDelay = this._PlayerCtrl.PlayerAnimation.Time_Duration * 0.5f;
        Invoke(nameof(this.ActionThrowShuriken), timeDelay);
    }

    protected virtual void ActionThrowShuriken()
    {
        Transform shurikenSpawned = WeaponCharacterSpawner.Instance.Spawn(WeaponCharacterSpawner.Name_Shuriken, this._Pos_Spawn_Shuriken.position, Quaternion.identity);

        //Set Direction fly
        ShurikenCtrl shurikenCtrl = shurikenSpawned.GetComponent<ShurikenCtrl>();

        Vector3 dir = this._PlayerCtrl.PlayerMovement.IsWallSliding ? -1f * this._PlayerCtrl.transform.localScale : this._PlayerCtrl.transform.localScale;
        shurikenCtrl.WeaponCharacterMovement.SetDirectionFly(dir);

        shurikenSpawned.localScale = Vector3.one;
        shurikenSpawned.name = WeaponCharacterSpawner.Name_Shuriken;
        shurikenSpawned.gameObject.SetActive(true);
    }
}

﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public abstract class ObjDamageReceiver : ObjectAbstract
{
    [Header("Obj Damage Receiver")]
    [SerializeField] protected float _maxHP;
    public float MaxHP => _maxHP;

    [SerializeField] protected float _currentHP;
    public float CurrentHp => _currentHP;


    [SerializeField] protected bool isDead;
    public bool ObjIsDead => isDead;

    [SerializeField] protected BoxCollider2D _BoxCollider2D;
    public BoxCollider2D BoxCollider2D => _BoxCollider2D;

    protected override void OnEnable()
    {
        base.OnEnable();
        this.ReBorn();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadColliderObject();
    }

    protected virtual void LoadColliderObject()
    {
        if (this._BoxCollider2D != null) return;

        this._BoxCollider2D = GetComponent<BoxCollider2D>();

    }
    //trừ child of DamRecriver dc base
    protected override void ResetValue()
    {
        this.ReBorn();
    }

    protected virtual void ReBorn()
    {
        this._maxHP = this.GetMaxHP();
        this._currentHP = this._maxHP;
        this.isDead = false;
    }

    protected virtual float GetMaxHP()
    {
        return 1;
    }

    public virtual void AddHP(float damage)
    {
        if (this.isDead) return;

        this._currentHP += damage;
        if (this._currentHP >= this._maxHP) return;
    }

    public virtual void DeductHP(float damage)
    {
        if (this.isDead) return;

        this._currentHP -= damage;

        if (this._currentHP > 0) return;

        this._currentHP = 0;
        this.isDead = true;
        this.OnDead();
    }

    protected abstract void OnDead();

    public virtual void IgnoreLayerCollisionOfPlayerObject(string layer_01, string layer_02, bool isInorged)
    {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer(layer_01), LayerMask.NameToLayer(layer_02), isInorged);
    }

}

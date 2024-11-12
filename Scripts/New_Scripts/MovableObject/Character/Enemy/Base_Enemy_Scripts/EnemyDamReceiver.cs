using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamReceiver : ObjDamageReceiver
{
    public EnemyCtrl EnemyCtrl => this._ObjectCtrl as EnemyCtrl;

    protected override void ReBorn()
    {
        base.ReBorn();
        this._BoxCollider2D.enabled = true;
        this.IgnoreLayerCollisionOfPlayerObject("Player", "WeaponPlayer", false);

    }
    protected override void Start()
    {
        base.Start();

        this.IgnoreLayerCollisionOfPlayerObject("Enemy", "PlayerHiddenMode", true);
        this.IgnoreLayerCollisionOfPlayerObject("Enemy", "Enemy", true);
        this.IgnoreLayerCollisionOfPlayerObject("Enemy", "WeaponEnemy", true);
        this.IgnoreLayerCollisionOfPlayerObject("Enemy", "Item", true);
        this.IgnoreLayerCollisionOfPlayerObject("Enemy", "ObjInteractableShuriken", true);
    }
    protected override float GetMaxHP()
    {
        return this.EnemyCtrl.EnemySO.Max_HP;// Load from Scriptable Object
    }
    protected override void OnDead()
    {
        this.EnemyCtrl.EnemyMovement.Rigidbody2D.bodyType = RigidbodyType2D.Static;
       // Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Enemy"), LayerMask.NameToLayer("WeaponPlayer"), true);

        //this._BoxCollider2D.enabled = false;
        Invoke(nameof(this.InActiveEnemy), 2f);
        //  Debug.Log(" Dead");
    }

    protected virtual void InActiveEnemy()
    {
        this.EnemyCtrl.gameObject.SetActive(false);

        //Cannot spawn again
        EnemySpawner.Instance.Despawn(this.EnemyCtrl.transform);
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision2D)
    {
        string nameLayerTurn = this.GetNameLayerImpactTrigger();
        if (this.CheckObjectImapactAllowedImpact(nameLayerTurn, collision2D.transform)) return;

        if (this.EnemyCtrl.EnemyCheckContactEnviroment.EnemyCheckForward.ForwardObjRight) return;

    }

    protected virtual string GetNameLayerImpactTrigger()
    {
        return "Player";
    }
    protected virtual bool CheckObjectImapactAllowedImpact(string nameLayerCheck, Transform parentObject)
    {
        return parentObject.gameObject.layer == LayerMask.NameToLayer(nameLayerCheck);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearTrapDamReceiver : ObjDamageReceiver
{
    [SerializeField] protected BearTrapCtrl _BearTrapCtrl => this._ObjectCtrl as BearTrapCtrl;

    protected override void OnDead()
    {
        this._BearTrapCtrl.ObjActionNipIndependantManager.TrapWasKilled();
        this._BoxCollider2D.enabled = false;
    }

    protected override void Start()
    {
        base.Start();

        this.SetIgnoreCollision();
    }

    protected virtual void SetIgnoreCollision()
    {
        this.IgnoreLayerCollisionOfPlayerObject("StopTrap", "Item", true);
        this.IgnoreLayerCollisionOfPlayerObject("StopTrap", "ItemLootable", true);
        this.IgnoreLayerCollisionOfPlayerObject("StopTrap", "WoodThing", true);

    }
}

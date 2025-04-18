using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearTrapDespawnByTIme : ObjDespawnByTime
{
    [SerializeField] protected BearTrapCtrl BearTrapCtrl => this._ObjectCtrl as BearTrapCtrl;

    public override void DespawnObject()
    {
        PlayerCtrl.Instance.PlayerMovement.IsStunned = false;

        this.BearTrapCtrl.gameObject.SetActive(false);
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        if (!PlayerCtrl.Instance.PlayerMovement.IsStunned) return;

        if (!PlayerCtrl.Instance.PlayerDamReceiver.ObjIsDead) return;

        this.DespawnObject();
    }
}

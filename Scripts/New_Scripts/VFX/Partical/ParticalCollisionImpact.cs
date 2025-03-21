﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticalCollisionImpact : ObjImpactBasement
{
    protected override void LoadRigidbody2D()
    {
        base.LoadRigidbody2D();

        this._Rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionY;
    }
    protected virtual void OnParticleCollision(GameObject other)
    {
        this.EventImpactEnter2D(other);
    }

    protected override bool CheckObjectImapactAllowedImpact()
    {
        if (this._parentObj.gameObject.layer == LayerMask.NameToLayer("Player")) return true;
        if (this._parentObj.gameObject.layer == LayerMask.NameToLayer("PlayerHiddenMode")) return true;

        return false;
    }
    protected override void ProcessAfterObjectImpacted()
    {
        this._ObjectCtrl.ObjDamageSender.Send(this._parentObj);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticalCollisionImpact : ObjImpactOverall
{

    protected virtual void OnParticleCollision(GameObject other)
    {
        this.EventImpactEnter2D(other);
    }

    protected override bool CheckObjectImapactAllowedImpactCollision() => this._parentObj.gameObject.layer == LayerMask.NameToLayer("Player");
    protected override void ProcessAfterObjectImapactCollision()
    {
        this._ObjectCtrl.ObjDamageSender.Send(this._parentObj);
    }
    
}

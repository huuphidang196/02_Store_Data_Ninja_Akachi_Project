using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenImpact : WeaponCharacterImpact
{
    //  public ShurikenCtrl ShurikenCtrl => this._ObjectCtrl as ShurikenCtrl;

    protected override void EventImpactEnter2D(GameObject col)
    {
        if (this.isImpact) return;

        base.EventImpactEnter2D(col);

        if (col.layer != LayerMask.NameToLayer("ObjInteractableShuriken")) return;

        ObjApplyForceAfterImpact objApply = col.GetComponentInChildren<ObjApplyForceAfterImpact>();

        if (objApply == null) return;

        // Hướng phản lực ngược với hướng va chạm
        Vector3 forceDirection = this.WeaponCharacterCtrl.WeaponCharacterMovement.Rigidbody2D.velocity.normalized;

        objApply.ApplyForce(col.transform.position, forceDirection);
    }
    protected override string[] GetArrayNameAllowImpact()
    {
        return new string[] { "Enemy", "ObjInteractableShuriken", "WeaponEnemy", "StaticProspect", "WoodThing" };
    }

    protected override string[] GetArrayNameTargetAttack()
    {
        return new string[] { "Enemy" };
    }
}

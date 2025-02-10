using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjImpactCircleColliderCollision : ObjImpactCircleCollider
{
   
    protected virtual void OnCollisionEnter2D(Collision2D col)
    {
        this.EventImpactEnter2D(col.gameObject);
    }    

    protected override void ProcessAfterObjectImpacted()
    {

    }

    protected override bool CheckObjectImapactAllowedImpact()
    {
        return true;
    }
}

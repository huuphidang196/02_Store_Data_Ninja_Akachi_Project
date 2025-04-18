using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterImpactTrigger : ObjImpactBoxColliderTrigger
{
    protected override void ProcessAfterObjectImpacted()
    {

    }

    protected override bool CheckObjectImapactAllowedImpact()
    {
        string[] nameLayerTurn = this.GetNameLayerImpactTrigger();
        return this.CheckParentObjectImpactWithAnyLayer(nameLayerTurn);
    }

    protected virtual string[] GetNameLayerImpactTrigger()
    {
        return new string[] { "" };
    }
}

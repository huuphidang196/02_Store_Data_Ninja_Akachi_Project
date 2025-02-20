using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObjImpactToChangeDir : ObjImpactBoxColliderTrigger
{
   // public MovableObjCtrl MovableObjCtrl => this._ObjectCtrl as MovableObjCtrl;
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
        return new string[] { "BoxChangeDir" };
    }
}

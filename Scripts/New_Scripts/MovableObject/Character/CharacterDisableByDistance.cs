using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDisableByDistance : ObjDisableOrEnableFollowTargetManager
{
    [SerializeField] protected CharacterCtrl _CharacterCtrl;
    public CharacterCtrl CharacterCtrl => _CharacterCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadCharacterCtrl();
    }

    protected virtual void LoadCharacterCtrl()
    {
        if (this._CharacterCtrl != null) return;

        this._CharacterCtrl = transform.parent.GetComponent<CharacterCtrl>();

        if (this._CharacterCtrl != null) return;

        this._CharacterCtrl = GetComponentInParent<CharacterCtrl>();
    }

    protected override void ResetValue()
    {
        base.ResetValue();

        this._Obj_Action = this._CharacterCtrl.transform;
    }

}

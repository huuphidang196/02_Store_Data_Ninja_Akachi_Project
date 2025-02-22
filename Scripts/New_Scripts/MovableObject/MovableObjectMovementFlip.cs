using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovableObjectMovementFlip : MovableObjMovement
{

    protected override void ResetValue()
    {
        base.ResetValue();

        this.ResetDataConfiguration();
    }

    protected virtual void ResetDataConfiguration()
    {
       
    }

    protected virtual void Update()
    {
        //if (GameController.Instance.PauseGame) return;

        if (this._MovableObjCtrl.ObjDamageReceiver != null && this._MovableObjCtrl.ObjDamageReceiver.ObjIsDead) this._Horizontal = 0;
        
        this.FucntionBaseUpdateMovableObjectMovement();       

    }

    protected virtual void FucntionBaseUpdateMovableObjectMovement()
    {
        this.Flip();
    }

    protected virtual void Flip()
    {
        if (this.isFacingRight && this._Horizontal < 0f || !this.isFacingRight && this._Horizontal > 0f) this.isFacingRight = !this.isFacingRight;

        this.ConductFlip();
    }

    protected virtual void ConductFlip()
    {
        Vector3 localScale = this._MovableObjCtrl.transform.localScale;
        localScale.x = (this.isFacingRight) ? Mathf.Abs(localScale.x) : -1f * Mathf.Abs(localScale.x);

        this._MovableObjCtrl.transform.localScale = localScale;
    }

    //protected abstract void UpdateBoolByInputManager();


}

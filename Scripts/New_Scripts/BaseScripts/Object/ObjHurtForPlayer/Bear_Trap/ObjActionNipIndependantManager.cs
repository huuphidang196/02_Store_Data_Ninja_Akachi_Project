using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjActionNipIndependantManager : ObjectAbstract
{
    [SerializeField] protected List<JawBearTrapCtrl> _List_JawBearTrapCtrl;
    public List<JawBearTrapCtrl> List_JawBearTrapCtrl => this._List_JawBearTrapCtrl;

    public BearTrapCtrl BearTrapCtrl => this._ObjectCtrl as BearTrapCtrl;

    [SerializeField] protected bool isTrapActivated = false;
    public bool IsTrapActivated => this.isTrapActivated;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadListObjActionNip();
    }

    protected virtual void LoadListObjActionNip()
    {
        if (this._List_JawBearTrapCtrl.Count > 0) return;

        foreach (Transform item in this.transform)
        {
            JawBearTrapCtrl nip = item.GetComponent<JawBearTrapCtrl>();
            this._List_JawBearTrapCtrl.Add(nip);
        }
    }

    public virtual void CloseTrap()
    {
        if (this.isTrapActivated) return;

        if (PlayerCtrl.Instance.PlayerMovement.IsDashing) return;

        this.BearTrapCtrl.ObjDamageReceiver.BoxCollider2D.enabled = false;

        foreach (JawBearTrapCtrl jaw in this._List_JawBearTrapCtrl)
        {
            jaw.ObjActionNip.SpringTarget();
        }

         this.BearTrapCtrl.VFX_Stun.gameObject.SetActive(true);

        //Remember Freeze Player
        this.RemoveComponentsAvoidTripping();

        PlayerCtrl.Instance.PlayerMovement.IsStunned = true;
     
        Invoke(nameof(this.SetPos), 0.2f);
    }

    protected virtual void SetPos()
    {
        this.BearTrapCtrl.transform.position = PlayerCtrl.Instance.transform.position;
    }    

    public virtual void TrapWasKilled()
    {
        
        //Call remov hingle and rigid
        foreach (JawBearTrapCtrl jaw in this._List_JawBearTrapCtrl)
        {
            jaw.ObjActionNip.DisableActionAfterDead();
        }
        this.RemoveComponentsAvoidTripping();

        //false vfx
        this.BearTrapCtrl.VFX_Stun.gameObject.SetActive(false);
    }

    protected virtual void RemoveComponentsAvoidTripping()
    {
        this.BearTrapCtrl.ObjDespawnByTime.gameObject.SetActive(true);

        this.isTrapActivated = true;
    }

   
}

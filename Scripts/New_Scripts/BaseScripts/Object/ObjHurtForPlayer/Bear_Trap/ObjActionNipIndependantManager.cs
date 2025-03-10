using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjActionNipIndependantManager : ObjectAbstract
{
    [SerializeField] protected List<JawBearTrapCtrl> _List_JawBearTrapCtrl;
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

        foreach (JawBearTrapCtrl jaw in this._List_JawBearTrapCtrl)
        {
            jaw.ObjActionNip.CloseTrap();
        }

        this.BearTrapCtrl.VFX_Stun.gameObject.SetActive(true);
        //Remember Freeze Player

        this.isTrapActivated = true;
        PlayerCtrl.Instance.PlayerMovement.IsStunned = true;
        Invoke(nameof(this.SetPos), 0.6f);
    }

    protected virtual void SetPos()
    {
        this.BearTrapCtrl.transform.position = PlayerCtrl.Instance.transform.position;
    }    

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public abstract class ObjImpactBasement : ObjectAbstract
{
    [Header("ObjImpactOverall")]
    //Từng weapon hay fx đều có radius riêng
    [SerializeField] protected Transform _parentObj;
    [SerializeField] protected bool isImpact = false;
    public bool IsImpact => isImpact;

    [SerializeField] protected Rigidbody2D _Rigidbody2D;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadRigidbody2D();
    }

    protected virtual void LoadRigidbody2D()
    {
        if (this._Rigidbody2D != null) return;

        this._Rigidbody2D = GetComponent<Rigidbody2D>();
        //this._rigidbody.isKinematic = true;
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        this.isImpact = false;
    }

    public virtual void SetChangeBoolImpact(bool boolChange) => this.isImpact = boolChange;
    protected virtual void EventImpactEnter2D(GameObject col)
    {
        if (this._ObjectCtrl.ObjDamageReceiver != null && this._ObjectCtrl.ObjDamageReceiver.ObjIsDead) return;

        this._parentObj = this.GetParent(col);

        bool allowImpact = this.CheckObjectImapactAllowedImpact();
        if (!allowImpact)
        {
            this._parentObj = null;
            return;
        }

        this.isImpact = true;

        this.ProcessAfterObjectImpacted();
        // Debug.Log(transform.name + " Impact " + collision.transform.name);
    }

    protected virtual Transform GetParent(GameObject col)
    {
        return (col.transform.parent == null) ? col.transform : col.transform.parent; ;
    }

    protected abstract bool CheckObjectImapactAllowedImpact();
    protected abstract void ProcessAfterObjectImpacted();

    protected virtual bool CheckParentObjectImpactWithAnyLayer(string nameLayerCheck)
    {
        return this._parentObj.gameObject.layer == LayerMask.NameToLayer(nameLayerCheck);
    }

    protected virtual bool CheckParentObjectImpactWithAnyLayer(string[] strnameLayerCheck)
    {
        foreach (string itemName in strnameLayerCheck)
        {
            if (this.CheckParentObjectImpactWithAnyLayer(itemName)) return true;
        }

        return false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class ObjImpactOverall : ObjectAbstract
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

    protected virtual void EventImpactEnter2D(GameObject collision)
    {
        this._parentObj = (collision.transform.parent == null) ? collision.transform : collision.transform.parent;

        bool allowImpact = this.CheckObjectImapactAllowedImpactCollision();
        if (!allowImpact)
        {
            this._parentObj = null;
            return;
        }

        this.isImpact = true;

        this.ProcessAfterObjectImapactCollision();
        // Debug.Log(transform.name + " Impact " + collision.transform.name);
    }

    protected virtual bool CheckObjectImapactAllowedImpactCollision() => false;
    protected abstract void ProcessAfterObjectImapactCollision();
}

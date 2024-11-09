using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjImpactOverall : ObjectAbstract
{
    [Header("ObjImpactOverall")]
    //Từng weapon hay fx đều có radius riêng
    [SerializeField] protected Transform _parentObj;
    [SerializeField] protected bool isImpact = false;
    public bool IsImpact => isImpact;

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

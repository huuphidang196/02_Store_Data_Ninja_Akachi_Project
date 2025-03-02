using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticBridgeProspectDropping : ObjectAbstract
{
    public StaticBridgeCtrl StaticBridgeCtrl => this._ObjectCtrl as StaticBridgeCtrl;

    [SerializeField] protected Vector3 _OldPos;
    [SerializeField] protected float _Time_Delay_Drop = 2f;
    protected override void Reset()
    {
        base.Reset();

        this._OldPos = this.StaticBridgeCtrl.transform.position;
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        this.StaticBridgeCtrl.transform.position = this._OldPos;
        this.StaticBridgeCtrl.Rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        this.StaticBridgeCtrl.Rigidbody2D.bodyType = RigidbodyType2D.Static;
    }

    public virtual void Dropped()
    {
        Invoke(nameof(this.SetDynamic), this._Time_Delay_Drop);
    }    

    protected virtual void SetDynamic()
    {
        this.StaticBridgeCtrl.Rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
    }    
}

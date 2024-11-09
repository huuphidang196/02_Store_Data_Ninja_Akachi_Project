using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ItemDropImpulse : SurMonoBehaviour
{
    [SerializeField] protected ItemDropCtrl _ItemDropCtrl;
    [SerializeField] protected Rigidbody2D _Rigidbody2D;

    [Range(0, 1)]
    [SerializeField] protected float _AVR_Force;
    [SerializeField] protected float _Force = 10f;
    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadItemDropCtrl();
        this.LoadRigidbody2D();
    }


    protected virtual void LoadItemDropCtrl()
    {
        if (this._ItemDropCtrl != null) return;

        this._ItemDropCtrl = GetComponentInParent<ItemDropCtrl>();
    }
    protected virtual void LoadRigidbody2D()
    {
        if (this._ItemDropCtrl == null) return;
        if (this._Rigidbody2D != null) return;

        this._Rigidbody2D = this._ItemDropCtrl.transform.GetComponent<Rigidbody2D>();
        this._Rigidbody2D.gravityScale = 5f;
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        this._Rigidbody2D.AddRelativeForce(this.GetVectorDirection() * this._Force, ForceMode2D.Impulse);

    }

    protected virtual Vector2 GetVectorDirection()
    {
        float x = Random.Range(-1f * this._AVR_Force, this._AVR_Force);
        float y = Random.Range(0.1f, 1f - this._AVR_Force);

        return new Vector2(x, y);
    }
}

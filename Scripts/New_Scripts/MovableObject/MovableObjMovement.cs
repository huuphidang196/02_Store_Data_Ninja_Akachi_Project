using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObjMovement : MovableObjAbstract
{
    [Header("MovableObjectMovement")]

    [SerializeField] protected Rigidbody2D _Rigidbody2D;
    public Rigidbody2D Rigidbody2D => _Rigidbody2D;

    [SerializeField] protected float _Horizontal = 0f;
    [SerializeField] protected float _Speed_Move_Horizontal = 8f;///Set from scriptable Object

    [SerializeField] protected bool isFacingRight = true;
    [SerializeField] protected bool _Move_Right = true;
    public bool Move_Right => this._Move_Right;
    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadRigidbody2D();
    }

    protected virtual void LoadRigidbody2D()
    {
        if (this._Rigidbody2D != null) return;

        this._Rigidbody2D = this._MovableObjCtrl.transform.GetComponent<Rigidbody2D>();
    }

}


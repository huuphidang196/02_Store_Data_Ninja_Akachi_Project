using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjRotate : ObjectAbstract
{
    [SerializeField] protected float _Speed = 100f; // Tốc độ quay

    protected virtual void Update()
    {
        this.RotatingObject();
    }

    protected virtual void RotatingObject()
    {
        this._ObjectCtrl.transform.Rotate(0, 0, this._Speed * Time.deltaTime);
    }

}

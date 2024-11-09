using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPatterImpluse : ItemDropImpulse
{
    protected override void OnEnable()
    {
        base.OnEnable();

        float torqueAmount = Random.Range(20f, 50f);
        // Xoay đối tượng theo trục Z
        //  this._ItemDropCtrl.transform.rotation = Quaternion.Euler(0f, 0f, zRotationAngle);
        this._Rigidbody2D.AddTorque(torqueAmount);
    }
}

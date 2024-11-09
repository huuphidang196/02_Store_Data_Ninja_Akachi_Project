using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class MinMaxPair
{
    public float Min;
    public float Max;

    public MinMaxPair(float min, float max)
    {
        this.Min = min;
        this.Max = max;
    }
}

[RequireComponent(typeof(Rigidbody2D))]

public class ItemDropCtrl : ObjectCtrl
{
    public ItemDamReceiver ItemDamReceiver => this._ObjDamageReceiver as ItemDamReceiver;

}

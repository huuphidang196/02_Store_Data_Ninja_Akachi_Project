using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicProspectEnableByDistanceManager : HolderObjectActivePoolByDistance
{
    [SerializeField] protected float _Active_Distance = 25f;

    protected override float GetActiveDistance()
    {
        return this._Active_Distance;
    }
}

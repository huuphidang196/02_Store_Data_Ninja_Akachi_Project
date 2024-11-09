using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjDamReceiverInfinity : ObjDamageReceiver
{
    protected override void OnDead()
    {
       
    }
    protected override float GetMaxHP()
    {
        return 999999f;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextLifePlayerRealTime : TextInfoPlayerUpdate
{
    protected override string GetDataValue()
    {
        return "" + PlayerCtrl.Instance.PlayerObjDead.Count_Life;
    }
}

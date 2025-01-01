using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextInfoPlayerUpdate : BaseText
{
    protected override void FixedUpdate()
    {
        this.UpdateContentByGetDataSystemConfig();
        base.FixedUpdate();
    }

    protected virtual void UpdateContentByGetDataSystemConfig()
    {
        string dataCongfig = this.GetDataValue();
        this.SetContent(dataCongfig);
    }

    protected virtual string GetDataValue()
    {
        return "";
    }
}

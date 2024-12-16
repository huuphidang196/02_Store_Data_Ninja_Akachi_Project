using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextShowGetValue : BaseText
{
    protected override void Start()
    {
        base.Start();
        string total = this.GetValueToShow();
        this.SetContent(total);
    }

    protected virtual string GetValueToShow()
    {
        return 0 + "";
    }
}

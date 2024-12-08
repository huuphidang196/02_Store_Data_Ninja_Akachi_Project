using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextMoneyTotalToShow : BaseText
{
    protected override void Start()
    {
        base.Start();

        string total = this.GetValueMoneyToShow();
        this.SetContent(total);       
    }

    protected virtual string GetValueMoneyToShow()
    {
        return 0.ToString();
    }
}

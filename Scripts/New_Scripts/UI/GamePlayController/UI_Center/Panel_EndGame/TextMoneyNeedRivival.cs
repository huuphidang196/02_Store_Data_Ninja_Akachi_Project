using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextMoneyNeedRivival : BaseText
{
    [SerializeField] protected TypeItem _TypeItem;

    protected override void Start()
    {
        base.Start();

        string valueMoneyNeeed = "" + GameController.Instance.GetValueMoneyToBuyTwoMoreLives(this._TypeItem);
        this.SetContent(valueMoneyNeeed);
    }
   
}

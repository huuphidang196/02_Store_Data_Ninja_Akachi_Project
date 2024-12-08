using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextDescription : BaseText
{
    [SerializeField] protected TextUICtrl _TextUICtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadTextFlyingCtrl();
    }

    protected virtual void LoadTextFlyingCtrl()
    {
        if (this._TextUICtrl != null) return;

        this._TextUICtrl = GetComponentInParent<TextUICtrl>();
    }
    public virtual void SetContentAndColor(ItemUnit itemUnit)
    {
        this.SetContent("+ " + itemUnit.Value);

        switch (itemUnit.TypeItem)
        {
            case TypeItemMoney.NoType:
                break;
            case TypeItemMoney.Gold:
                this._BaseText.color = Color.yellow;
                break;
            case TypeItemMoney.Diamond:
                this._BaseText.color = Color.blue;
                break;
            case TypeItemMoney.Star_Mission:
                this._BaseText.color = Color.white;
                break;
        }
    }
}
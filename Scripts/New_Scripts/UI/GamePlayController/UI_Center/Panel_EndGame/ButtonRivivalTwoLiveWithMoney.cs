using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonRivivalTwoLiveWithMoney : BaseButton
{
    [SerializeField] protected TypeItemMoney _TypeItem;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadTypeItem();
    }

    protected virtual void LoadTypeItem()
    {
        if (this._TypeItem != TypeItemMoney.NoType) return;

        // Tìm phần đuôi sau dấu gạch dưới (_), ví dụ: "Gold" hoặc "Diamond"
        string typeName = this.transform.name.Substring(this.transform.name.LastIndexOf('_') + 1);

        // Thử chuyển đổi chuỗi thành giá trị enum
        if (System.Enum.TryParse(typeName, out TypeItemMoney itemType))
        {
            this._TypeItem = itemType;
        }
        else
        {
            this._TypeItem = TypeItemMoney.NoType; // Mặc định nếu không tìm thấy
        }
    }

    protected override void OnClick()
    {
        base.OnClick();

        GamePlayController.Instance.RiviveCharacterByMoneyWitTwoLives(this._TypeItem);
    }
}

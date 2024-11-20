using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBuyDiamonds : BaseButton
{
    [SerializeField] protected ItemUnit _ItemUnit;

    protected override void Reset()
    {
        base.Reset();

        this._ItemUnit.TypeItem = TypeItem.Diamond;

        // Tách số từ tên button (giữa ký tự '_' đầu tiên và thứ hai)
        string[] parts = this.gameObject.name.Split('_');
        string numberString = parts[1];

        // Chuyển đổi số nếu cần
        if (int.TryParse(numberString, out int number))
        {
            this._ItemUnit.Value = number;
        }
    }

    protected override void OnClick()
    {
        base.OnClick();

        GameController.Instance.AddMoneyToSystem(this._ItemUnit);
    }
}

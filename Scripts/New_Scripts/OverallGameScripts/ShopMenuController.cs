using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMenuController : SystemController
{
    private static ShopMenuController m_instance;
    public static ShopMenuController Instance => m_instance;

    public static Action<int> Event_Completed_Transaction;

    protected override void Awake()
    {
        base.Awake();

        if (m_instance != null) Debug.LogError("Allow only ShopMenuController has been exist");

        m_instance = this;
    }

    public virtual void EquipOrBuyingSkinHidenMode()
    {
        int order = UICenterShopManager.Instance.UICenterShopCtrl.UIShopCenterDisguiseManager.Order_Skin_Selecting;
        // Attempt unlock all
        SkinHidenMode skinPurchasing = this._SystemConfig.ShopControllerSO.DisguiseConfigSO.Skins_Hiden_Mode[order];

        if (skinPurchasing.Unlock)
        {
            this._SystemConfig.ShopControllerSO.DisguiseConfigSO.Order_Skin_Equipped = order;
            UIShopCenterDisguiseManager.Event_Equip_NewSkin?.Invoke(order);
            return;
        }

        if (!this.DeductMoneyToSystem(skinPurchasing.ItemMoneyUnit.ItemUnit.TypeItem, skinPurchasing.ItemMoneyUnit.ItemUnit.Value)) return;

        skinPurchasing.Unlock = true;
        //this._SystemConfig.ShopControllerSO.DisguiseConfigSO.Order_Skin_Equipped = order;
        Event_Completed_Transaction?.Invoke(order);

    }

}

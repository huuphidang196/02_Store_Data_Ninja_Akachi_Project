using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonStatusPurchasingManager : SurMonoBehaviour
{
    [SerializeField] protected Button _btnExcecute;

    [SerializeField] protected TextMeshProUGUI _txtTextStatus;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadButtonExecute();

        this.LoadTextStatus();
    }

    protected virtual void LoadTextStatus()
    {
        if (this._txtTextStatus != null) return;

        this._txtTextStatus = GetComponentInChildren<TextMeshProUGUI>();
    }

    protected virtual void LoadButtonExecute()
    {
        if (this._btnExcecute != null) return;

        this._btnExcecute = GetComponentInChildren<Button>();
    }

    protected override void Start()
    {
        base.Start();

        UIShopCenterDisguiseManager.Event_Select_Other_Skin += this.EventChangeSelectedSkinHiden;
        ShopMenuController.Event_Completed_Transaction += this.EventChangeSelectedSkinHiden;
        UIShopCenterDisguiseManager.Event_Equip_NewSkin += EventChangeSelectedSkinHiden;
    }

    protected virtual void OnDestroy()
    {
        UIShopCenterDisguiseManager.Event_Select_Other_Skin -= this.EventChangeSelectedSkinHiden;
        ShopMenuController.Event_Completed_Transaction -= this.EventChangeSelectedSkinHiden;
        UIShopCenterDisguiseManager.Event_Equip_NewSkin -= EventChangeSelectedSkinHiden;
    }
    protected virtual void EventChangeSelectedSkinHiden(int order)
    {
        bool wasEquipped = (order == ShopMenuController.Instance.SystemConfig.ShopControllerSO.DisguiseConfigSO.Order_Skin_Equipped);
        //Check Has SkinMode been Selected
        Image imageBtn = this._btnExcecute.GetComponentInChildren<Image>();
        this._btnExcecute.gameObject.SetActive(!wasEquipped);

        //Text
        this._txtTextStatus.gameObject.SetActive(!wasEquipped);
        bool wasPurchased = ShopMenuController.Instance.SystemConfig.ShopControllerSO.DisguiseConfigSO.Skins_Hiden_Mode[order].BaseThingUnlock.Unlock;
        this._txtTextStatus.text = wasPurchased ? "EQUIP" : "PURCHASE";
        if (!wasEquipped) imageBtn.color = wasPurchased ? new Color(178f / 255f, 34f / 255f, 34f / 255f) : Color.white;
    }

}

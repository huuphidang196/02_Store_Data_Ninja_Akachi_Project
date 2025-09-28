using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ButtonSkinHidenModeManager : UIButtonContainLightSelected
{
    [Header("ButtonSkinHidenModeManager")]
    [SerializeField] protected SkinHidenMode _SkinHidenMode;

    [SerializeField] protected Image _Sprite_Equipped;
    [SerializeField] protected TextMeshProUGUI _txtPrice;
    [SerializeField] protected Image _Image_Money_Rep;
    [SerializeField] protected Image _Image_Skin_Rep;
    [SerializeField] protected TextMeshProUGUI _txtNameSkin;

    public virtual void SetSkinHidenMode(SkinHidenMode skinHidenMode) => this._SkinHidenMode = skinHidenMode;

    #region LoadComponents
    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadSpriteEquipped();
        this.LoadTextPrice();
        this.LoadImageMoneyRepresent();
        this.LoadImageSkinRepresent();
        this.LoadTextNameMode();
    }

    protected virtual void LoadSpriteEquipped()
    {
        if (this._Sprite_Equipped != null) return;

        this._Sprite_Equipped = transform.Find("Sprite_Equipped").GetComponent<Image>();
        this._Sprite_Equipped.gameObject.SetActive(false);
    }
    protected virtual void LoadTextPrice()
    {
        if (this._txtPrice != null) return;

        this._txtPrice = transform.Find("txtPrice").GetComponent<TextMeshProUGUI>();
    }
    protected virtual void LoadImageMoneyRepresent()
    {
        if (this._Image_Money_Rep != null) return;

        this._Image_Money_Rep = transform.Find("Image_Money_Rep").GetComponent<Image>();
    }

    protected virtual void LoadImageSkinRepresent()
    {
        if (this._Image_Skin_Rep != null) return;

        this._Image_Skin_Rep = transform.Find("Image_Skin_Rep").GetComponent<Image>();
    }

    protected virtual void LoadTextNameMode()
    {
        if (this._txtNameSkin != null) return;

        this._txtNameSkin = transform.Find("txtName_Mode").GetComponent<TextMeshProUGUI>();
    }

    #endregion LoadComponents

    protected override void OnEnable()
    {
        base.OnEnable();

        if (this._SkinHidenMode == null) return;

        this._Light_Selected.gameObject.SetActive(false);
        this._Sprite_Equipped.gameObject.SetActive(false);

        this.UpdateStatusHidenMode();

        this.EventChangeEquipSkinMode(0);
    }

    protected override void Start()
    {
        base.Start();
        UIShopCenterDisguiseManager.Event_Select_Other_Skin += this.EventChangeOtherSkinHiden;
        UIShopCenterDisguiseManager.Event_Equip_NewSkin += this.EventChangeEquipSkinMode;
        ShopMenuController.Event_Completed_Transaction += this.EventComTransactionUpdateStatusHidenMode;
    }
    protected virtual void EventComTransactionUpdateStatusHidenMode(int order)
    {
        this.UpdateStatusHidenMode();
    }
    protected virtual void UpdateStatusHidenMode()
    {
        //Text Price
        this._txtPrice.text = this._SkinHidenMode.BaseDataUnlock.Unlock ? "PURCHASED" : this._SkinHidenMode.ItemMoneyUnit.ItemUnit.Value.ToString();

        this._txtPrice.color = this._SkinHidenMode.ItemMoneyUnit.Color_Text;

        this._Image_Money_Rep.sprite = this._SkinHidenMode.ItemMoneyUnit.Sprite_Represent_Money;
        this._Image_Skin_Rep.sprite = this._SkinHidenMode.Sprite_Rep_Skin;

        this._txtNameSkin.text = this._SkinHidenMode.BaseDataUnlock.Name_Data;
    }

    protected virtual void EventChangeOtherSkinHiden(int order_Skin)
    {
        bool isSelecting = this.transform.GetSiblingIndex() == order_Skin;

        this._Light_Selected.gameObject.SetActive(isSelecting);
    }

    protected virtual void EventChangeEquipSkinMode(int order)
    {
        bool wasEquipped = this.transform.GetSiblingIndex() == SystemController.Sys_Instance.SystemConfig.ShopControllerSO.DisguiseConfigSO.Order_Skin_Equipped;

        this._Image_Money_Rep.sprite = wasEquipped ? SystemController.Sys_Instance.SystemConfig.ShopControllerSO.DisguiseConfigSO.Sprite_Rep_Eqqiped_Overall : this._SkinHidenMode.ItemMoneyUnit.Sprite_Represent_Money;

        this._Sprite_Equipped.gameObject.SetActive(wasEquipped);
        if (wasEquipped)
        {
            this._txtPrice.text = "EQUIPPED";
            return;
        }
        this._txtPrice.text = this._SkinHidenMode.BaseDataUnlock.Unlock ? "PURCHASED" : this._SkinHidenMode.ItemMoneyUnit.ItemUnit.Value.ToString();

    }
    protected virtual void OnDestroy()
    {
        UIShopCenterDisguiseManager.Event_Select_Other_Skin -= this.EventChangeOtherSkinHiden;
        UIShopCenterDisguiseManager.Event_Equip_NewSkin -= this.EventChangeEquipSkinMode;
        ShopMenuController.Event_Completed_Transaction -= this.EventComTransactionUpdateStatusHidenMode;
    }

}

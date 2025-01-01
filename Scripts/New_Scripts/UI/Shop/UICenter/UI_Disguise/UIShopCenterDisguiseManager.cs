using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIShopCenterDisguiseManager : UICenterShopCtrlAbstract
{
    [SerializeField] protected UIShopCenterSpawner _UIShopCenterSpawner;
    public UIShopCenterSpawner UIShopCenterSpawner => this._UIShopCenterSpawner;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadUIShopCenterSpawner();
    }

    protected virtual void LoadUIShopCenterSpawner()
    {
        if (this._UIShopCenterSpawner != null) return;

        this._UIShopCenterSpawner = GetComponentInChildren<UIShopCenterSpawner>();
    }
    protected override void Start()
    {
        base.Start();

        this.SpawnSkinHidenMode();
    }

    protected virtual void SpawnSkinHidenMode()
    {
        List<SkinHidenMode> skins_Hiden_Mode = ShopMenuController.Instance.SystemConfig.ShopControllerSO.DisguiseConfigSO.Skins_Hiden_Mode;

        foreach (SkinHidenMode item in skins_Hiden_Mode)
        {
            Transform skin = this._UIShopCenterSpawner.Spawn(UIShopCenterSpawner.Button_Skin_Hiden_Mode, Vector2.zero, Quaternion.identity);
            ButtonSkinHidenModeManager skinHidenModeManager = skin.GetComponent<ButtonSkinHidenModeManager>();

            //Set Skin
            skinHidenModeManager.SetSkinHidenMode(item);

            skin.name += "_" + (transform.GetSiblingIndex() + 1).ToString("D2");
            skin.localScale = Vector3.one;
            skin.gameObject.SetActive(true);
        }
    }
}

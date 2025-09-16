using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class ShopPurchasing : SurMonoBehaviour
{
    private string _add1000Diamonds = "com.kairoxstudio.ninjakairox.add1000diamonds";
    private string _add2500Diamonds = "com.kairoxstudio.ninjakairox.add2500diamonds";
    private string _add7500Diamonds = "com.kairoxstudio.ninjakairox.add7500diamonds";
    private string _add20000Diamonds = "com.kairoxstudio.ninjakairox.add20000diamonds";
    private string _removeAds = "com.kairoxstudio.ninjakairox.removeads";

    //Artifact
    private string _Onimori = "com.kairoxstudio.ninjakairox.onimori";
    private string _Golden_Shuriken = "com.kairoxstudio.ninjakairox.goldenshuriken";
    private string _Sacred_Tsuka = "com.kairoxstudio.ninjakairox.sacredtsuka";
    private string _Coin_Of_Luck = "com.kairoxstudio.ninjakairox.coinofluck";

    public virtual void OnPurchaseComplete(Product product)
    {

        if (product.definition.id == this._add1000Diamonds)
        {
            this.ProcessOnPurchaseItemUnitCompleted(1000);
        }
        else if (product.definition.id == this._add2500Diamonds)
        {
            this.ProcessOnPurchaseItemUnitCompleted(2500);
        }
        else if (product.definition.id == this._add7500Diamonds)
        {
            this.ProcessOnPurchaseItemUnitCompleted(7500); 
        }
        else if (product.definition.id == this._add20000Diamonds)
        {
            this.ProcessOnPurchaseItemUnitCompleted(20000);
        }
        else if (product.definition.id == this._removeAds)
        {
            //RemoveAds + SaveGame
            SystemController.Sys_Instance.SystemConfig.ShopControllerSO.WasRemoved_AdsInterstitial = true;
        }
        else if (product.definition.id == this._Onimori)
        {
            this.ProcessOnPurchasedArtifactCompleted(TypeNameArtifact.Onimori);
        }
        else if (product.definition.id == this._Golden_Shuriken)
        {
            this.ProcessOnPurchasedArtifactCompleted(TypeNameArtifact.Golden_Shuriken);
        }
        else if (product.definition.id == this._Sacred_Tsuka)
        {
            this.ProcessOnPurchasedArtifactCompleted(TypeNameArtifact.Sacred_Tsuka);
        }
        else if (product.definition.id == this._Coin_Of_Luck)
        {
            this.ProcessOnPurchasedArtifactCompleted(TypeNameArtifact.Coin_Of_Luck);
        }

        SaveManager.Instance.SaveGame();
        // Debug.Log("Success");
        // this._txtReason.text = "Unlock all Knives Success";
    }

    protected virtual void ProcessOnPurchaseItemUnitCompleted(float value)
    {
        ItemUnit itemUnit = new ItemUnit(value, TypeItemMoney.Diamond);
        IAPManager.Instance.ProcessBuyDiamonds(itemUnit);
    }

    protected virtual void ProcessOnPurchasedArtifactCompleted(TypeNameArtifact typeArt)
    {
        ArtifactItem arti = SystemController.Sys_Instance.SystemConfig.ArtifactConfigSO.GetArtifactConfigSOByTypeName(typeArt);

        ArtifactSceneManager.Instance.UnlockArtifactByPurchasing(arti);
    }

    public virtual void OnPurchaseFailure(Product product, PurchaseFailureDescription reason)
    {
        // Debug.Log("Reason : " + reason);
        // this._txtReason.text = "Faild, Reason : " + reason;
    }


}

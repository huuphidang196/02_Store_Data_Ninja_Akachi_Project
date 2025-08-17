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
        ItemUnit itemUnit = new ItemUnit(0, TypeItemMoney.Diamond);

        if (product.definition.id == this._add1000Diamonds)
        {
            itemUnit.Value = 1000;
            IAPManager.Instance.ProcessBuyDiamonds(itemUnit);
        }
        else if (product.definition.id == this._add2500Diamonds)
        {
            itemUnit.Value = 2500;
            IAPManager.Instance.ProcessBuyDiamonds(itemUnit);
        }
        else if (product.definition.id == this._add7500Diamonds)
        {
            itemUnit.Value = 7500;
            IAPManager.Instance.ProcessBuyDiamonds(itemUnit);
        }
        else if (product.definition.id == this._add20000Diamonds)
        {
            itemUnit.Value = 20000;
            IAPManager.Instance.ProcessBuyDiamonds(itemUnit);
        }
        else if (product.definition.id == this._removeAds)
        {
            //RemoveAds + SaveGame
            SystemController.Sys_Instance.SystemConfig.ShopControllerSO.WasRemoved_Ads = true;
        }
        else if (product.definition.id == this._Onimori)
        {
            //RemoveAds + SaveGame
            ArtifactItem arti = SystemController.Sys_Instance.SystemConfig.ArtifactConfigSO.GetArtifactConfigSOByTypeName(TypeNameArtifact.Onimori);
            arti.Unlock = true;
        }
        else if (product.definition.id == this._Golden_Shuriken)
        {
            //RemoveAds + SaveGame
            ArtifactItem arti = SystemController.Sys_Instance.SystemConfig.ArtifactConfigSO.GetArtifactConfigSOByTypeName(TypeNameArtifact.Golden_Shuriken);
            arti.Unlock = true;
        }
        else if (product.definition.id == this._Sacred_Tsuka)
        {
            //RemoveAds + SaveGame
            ArtifactItem arti = SystemController.Sys_Instance.SystemConfig.ArtifactConfigSO.GetArtifactConfigSOByTypeName(TypeNameArtifact.Sacred_Tsuka);
            arti.Unlock = true;
        }
        else if (product.definition.id == this._Coin_Of_Luck)
        {
            //RemoveAds + SaveGame
            ArtifactItem arti = SystemController.Sys_Instance.SystemConfig.ArtifactConfigSO.GetArtifactConfigSOByTypeName(TypeNameArtifact.Coin_Of_Luck);
            arti.Unlock = true;
        }

        SaveManager.Instance.SaveGame();
        // Debug.Log("Success");
        // this._txtReason.text = "Unlock all Knives Success";
    }

    public virtual void OnPurchaseFailure(Product product, PurchaseFailureDescription reason)
    {
        // Debug.Log("Reason : " + reason);
        // this._txtReason.text = "Faild, Reason : " + reason;
    }


}

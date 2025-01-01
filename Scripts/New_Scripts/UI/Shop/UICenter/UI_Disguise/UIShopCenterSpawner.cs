using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIShopCenterSpawner : Spawner
{
    public static string Button_Skin_Hiden_Mode = "Button_Skin_Hiden_Mode";
    protected override void LoadHolder()
    {
        if (this._holder != null) return;
        this._holder = this.transform.Find("Scroll View").Find("Viewport").Find("Content");
    }
}

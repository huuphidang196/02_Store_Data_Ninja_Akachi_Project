using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonWatchAdsFreeDiamonds : BaseButton
{
    protected override void OnClick()
    {
        base.OnClick();
       
        UIBelowMainMenuSceneManager.Instance.ProcessWatchAdsFreeDiamonds();

    }

   
}

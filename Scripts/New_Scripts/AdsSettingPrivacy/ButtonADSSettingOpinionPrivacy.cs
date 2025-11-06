using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonADSSettingOpinionPrivacy : BaseButton
{
    [SerializeField] protected bool isAccept = true;
    protected override void OnClick()
    {
        base.OnClick();

        this.transform.parent.gameObject.SetActive(false);
        SystemController.Sys_Instance.ChangeAdsSettingPrivacy(this.isAccept);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIIntroduceSetActiveOnlyLevelOne : SurMonoBehaviour
{
    [SerializeField] protected GuidanceButtonFirstTime _Type_Guidance_Button;

    [SerializeField] protected ButtonActiveParent _ButtonActiveParent;
    public ButtonActiveParent ButtonActiveParent => this._ButtonActiveParent;


    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadButtonActiveParent();
    }

    protected virtual void LoadButtonActiveParent()
    {
        if (this._ButtonActiveParent != null) return;

        this._ButtonActiveParent = GetComponentInParent<ButtonActiveParent>();

        this._ButtonActiveParent.BaseButton_Exect.gameObject.SetActive(false);
    }

    protected override void Start()
    {
        base.Start();

        this.CheckHasGuidedUsingButton();
    }

    protected virtual void CheckHasGuidedUsingButton()
    {
        if (!GamePlayController.Instance.SystemConfig.isGuidedButton) return;

        this._ButtonActiveParent.BaseButton_Exect.gameObject.SetActive(true);

        this.gameObject.SetActive(false);
    }

    protected virtual void Update()
    {
        if (this._ButtonActiveParent.BaseButton_Exect.gameObject.activeInHierarchy) return;

        this._ButtonActiveParent.BaseButton_Exect.gameObject.SetActive(GuidanceFirstTimePlaying.Instance.GetBoolActiveButton(this._Type_Guidance_Button));
    }

  
}

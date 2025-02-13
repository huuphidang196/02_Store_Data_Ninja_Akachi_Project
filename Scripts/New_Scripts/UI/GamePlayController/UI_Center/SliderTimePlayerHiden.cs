using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SliderTimePlayerHiden : BaseSlider
{
    [SerializeField] protected GamePlayUICenter _GamePlayUICenter;
    [SerializeField] protected float _TimeDelay_Hidden = 5f;
  
    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadGamePlayUICenter();
    }

    protected virtual void LoadGamePlayUICenter()
    {
        if (this._GamePlayUICenter != null) return;

        this._GamePlayUICenter = transform.parent.GetComponent<GamePlayUICenter>();
    }

    protected override void ResetValue()
    {
        base.ResetValue();

        this._TimeDelay_Hidden = this._GamePlayUICenter.GamePlayUIOverall.GamePlayConfigUIOverall.SystemConfig.PlayerSO.Time_Delay_Hiden;

        this.slider.minValue = 0f;
        this.slider.maxValue = this._TimeDelay_Hidden;

        this.ResetValueSliderBegin();
    }


    public virtual void ResetValueSliderBegin()
    {
        this.slider.value = this._TimeDelay_Hidden;
    }
    protected override void OnValueChange(float value)
    {


    }

    protected virtual void Update()
    {

        // if (this.slider.value <= 0 || PlayerCtrl.Instance.PlayerDamReceiver.ObjIsDead) this.gameObject.SetActive(false);

        this.slider.value -= Time.deltaTime;



    }
}

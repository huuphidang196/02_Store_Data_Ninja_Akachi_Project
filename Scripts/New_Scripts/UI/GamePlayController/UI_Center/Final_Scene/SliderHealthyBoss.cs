using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderHealthyBoss : BaseSlider
{
    protected override void LoadSlider()
    {
        base.LoadSlider();

        this.slider.minValue = 0f;

        this.slider.maxValue = 100f;
    }
    protected override void OnValueChange(float value)
    {
       
    }

    protected virtual void FixedUpdate()
    {
        if (BossCtrl.Instance == null) return;


        this.slider.value = BossCtrl.Instance.ObjDamageReceiver.CurrentHp;
    }    
}

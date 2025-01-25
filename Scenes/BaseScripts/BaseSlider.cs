using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public abstract class BaseSlider : SurMonoBehaviour
{
    [SerializeField] protected Slider slider;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSlider();

    }

    protected override void Start()
    {
        base.Start();
        this.AddOnClickEvent();
    }
 

    protected virtual void LoadSlider()
    {
        if (this.slider != null) return;
        this.slider = GetComponent<Slider>();

    }

    protected virtual void AddOnClickEvent()
    {
        this.slider.onValueChanged.AddListener(this.OnValueChange);
    }
    protected abstract void OnValueChange(float value);
      
}

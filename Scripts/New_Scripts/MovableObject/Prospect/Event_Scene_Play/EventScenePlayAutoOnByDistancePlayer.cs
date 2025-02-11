using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EventScenePlayAutoOnByDistancePlayer : SurMonoBehaviour
{
    [SerializeField] protected float activationDistance = 5f; // Khoảng cách để kích hoạt
    [SerializeField] protected bool activated = false; // Đánh dấu đã kích hoạt hay chưa
    public bool LancesActivated => this.activated;

    protected override void ResetValue()
    {
        base.ResetValue();
        this.activated = false;
    }
    protected virtual void Update()
    {
        // Kiểm tra khoảng cách với Player
        if (activated) return;

        float distance = this.transform.position.x - PlayerCtrl.Instance.transform.position.x;
        if (distance < activationDistance)
        {
            activated = true;
            this.ConductActionEvents();
        }
    }

    protected abstract void ConductActionEvents();
    
}

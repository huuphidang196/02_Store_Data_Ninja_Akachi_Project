using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EventScenePlayAutoOnByDistancePlayer : SurMonoBehaviour
{
    [SerializeField] protected float activationDistance = 25f; // Khoảng cách để kích hoạt
    [SerializeField] protected bool activated = false; // Đánh dấu đã kích hoạt hay chưa
    public bool Activated => this.activated;

    protected override void ResetValue()
    {
        base.ResetValue();
        this.activated = false;
    }
    protected virtual void FixedUpdate()
    {
        // Kiểm tra khoảng cách với Player
        if (activated) return;

        if (this.AllowActive())
        {
            activated = true;
            this.ConductActionEvents();
        }
    }

    protected virtual bool AllowActive()
    {
        return this.GetDistance() <= activationDistance;
    }

    protected virtual float GetDistance() => this.transform.position.x - PlayerCtrl.Instance.transform.position.x;

    protected abstract void ConductActionEvents();

}

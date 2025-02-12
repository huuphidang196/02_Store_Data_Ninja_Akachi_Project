using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScytheOfDeathRotating : ObjectAbstract
{
    [Header("ScytheOfDeathRotating")]
    [SerializeField] protected HingeJoint _HingeJoint;
    [SerializeField]
    protected float _Timer = 0f;
    [SerializeField]
    protected float _TimeDelay = 3f;

    [SerializeField] protected float _Spring_Value = 120f;

    [SerializeField] protected MinMaxPair _TargetRot = new MinMaxPair(-160f, -20f);
    [SerializeField] protected MinMaxPair _LimitRot = new MinMaxPair(-179f, -1f);


    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadHingeJoint();
    }

    protected virtual void LoadHingeJoint()
    {
        if (this._HingeJoint != null) return;

        this._HingeJoint = GetComponentInParent<HingeJoint>();
        this._HingeJoint.useSpring = true;
        this._HingeJoint.useLimits = true;
    }

    protected override void ResetValue()
    {
        base.ResetValue();

        JointSpring Spring = this._HingeJoint.spring;
        Spring.spring = 120f;
        Spring.targetPosition = _TargetRot.Max;
        this._HingeJoint.spring = Spring;

        // Tạo cấu trúc JointLimits mới
        JointLimits limits = this._HingeJoint.limits;
        limits.min = this._LimitRot.Min;  // Giới hạn góc nhỏ nhất
        limits.max = this._LimitRot.Max;   // Giới hạn góc lớn nhất

        // Gán giới hạn vào HingeJoint
        this._HingeJoint.limits = limits;
    }

    protected virtual void Update()
    {
        this._Timer += Time.deltaTime;

        if (this._Timer < this._TimeDelay) return;

        JointSpring Spring = this._HingeJoint.spring;
        Spring.targetPosition = (this._HingeJoint.spring.targetPosition == this._TargetRot.Min) ? this._TargetRot.Max : this._TargetRot.Min;
        this._Timer = 0f;
        this._HingeJoint.spring = Spring;
    }    
}

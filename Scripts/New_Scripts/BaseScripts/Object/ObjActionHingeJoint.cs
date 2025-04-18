﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjActionHingeJoint : ObjectAbstract
{
    [Header("ObjActionNipOverall")]
    [SerializeField] protected HingeJoint _HingeJoint;
    [SerializeField] protected Rigidbody _Rid;

    [SerializeField] protected float _Spring_Value = 120f;

    [SerializeField] protected MinMaxPair _TargetRot;
    [SerializeField] protected MinMaxPair _LimitRot;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadHingeJoint();
        this.LoadRigidbody();
    }


    protected virtual void LoadHingeJoint()
    {
        if (this._HingeJoint != null) return;

        this._HingeJoint = GetComponentInParent<HingeJoint>();
        this._HingeJoint.useSpring = true;
        this._HingeJoint.useLimits = true;
    }
    protected virtual void LoadRigidbody()
    {
        if (this._Rid != null) return;

        this._Rid = GetComponentInParent<Rigidbody>();
    }

    protected override void ResetValue()
    {
        base.ResetValue();

        JointSpring Spring = this._HingeJoint.spring;

        Spring.targetPosition = _TargetRot.Min;
        this._HingeJoint.spring = Spring;

        // Tạo cấu trúc JointLimits mới
        JointLimits limits = this._HingeJoint.limits;
        limits.min = this._LimitRot.Min;  // Giới hạn góc nhỏ nhất
        limits.max = this._LimitRot.Max;   // Giới hạn góc lớn nhất

        // Gán giới hạn vào HingeJoint
        this._HingeJoint.limits = limits;
    }
    public virtual void SpringTarget()
    {
        JointSpring Spring = this._HingeJoint.spring;
        Spring.targetPosition = this._TargetRot.Max;

        this._HingeJoint.spring = Spring;
    }
}

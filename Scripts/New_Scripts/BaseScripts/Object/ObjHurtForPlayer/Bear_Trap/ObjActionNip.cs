using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjActionNip : ObjectAbstract
{
    [Header("ObjActionNip")]
    [SerializeField] protected HingeJoint _HingeJoint;

    [SerializeField] protected float _Spring_Value = 120f;

    [SerializeField] protected MinMaxPair _TargetRot;
    [SerializeField] protected MinMaxPair _LimitRot;

    [SerializeField] protected bool isTriggered = false;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadHingeJoint();
    }

    protected virtual void LoadHingeJoint()
    {
        if (this._HingeJoint != null) return;

        this._HingeJoint = GetComponent<HingeJoint>();
        this._HingeJoint.useSpring = true;
        this._HingeJoint.useLimits = true;
    }

    protected override void ResetValue()
    {
        base.ResetValue();

        JointSpring Spring = this._HingeJoint.spring;
        Spring.spring = 120f;
        Spring.targetPosition = _TargetRot.Min;
        this._HingeJoint.spring = Spring;

        // Tạo cấu trúc JointLimits mới
        JointLimits limits = this._HingeJoint.limits;
        limits.min = this._LimitRot.Min;  // Giới hạn góc nhỏ nhất
        limits.max = this._LimitRot.Max;   // Giới hạn góc lớn nhất

        // Gán giới hạn vào HingeJoint
        this._HingeJoint.limits = limits;
    }

    public virtual void CloseTrap()
    {
        if (this.isTriggered) return;

        JointSpring Spring = this._HingeJoint.spring;
        Spring.targetPosition = this._TargetRot.Max;

        this._HingeJoint.spring = Spring;
    }

}

/*
    [SerializeField] protected HingeJoint2D _LeftJaw;
    [SerializeField] protected HingeJoint2D _RightJaw;

    [SerializeField] protected float _TrapForce = 200f;  // Lực kẹp

    [SerializeField] protected bool isTriggered = false;
    public bool Test = false;
    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadLeftJaw();
        this.LoadRightJaw();
    }

    protected virtual void LoadLeftJaw()
    {
        if (this._LeftJaw != null) return;

        this._LeftJaw = transform.Find("Jaw_Left").GetComponent<HingeJoint2D>();
    }
    protected virtual void LoadRightJaw()
    {
        if (this._RightJaw != null) return;

        this._RightJaw = transform.Find("Jaw_Right").GetComponent<HingeJoint2D>();
    }


    public virtual void CloseTrap()
    {
        if (this.isTriggered) return;

        JointMotor2D motor = _LeftJaw.motor;
        motor.motorSpeed = -_TrapForce; // Đóng hàm trái
        _LeftJaw.motor = motor;

        motor.motorSpeed = _TrapForce; // Đóng hàm phải
        _RightJaw.motor = motor;
    }

    protected virtual void Update()
    {
        if (this.Test) return;

        this.CloseTrap();
    }    
*/
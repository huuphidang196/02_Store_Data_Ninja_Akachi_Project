using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjActionNip : ObjectAbstract
{
    [Header("ObjActionNip")]
    [SerializeField] protected HingeJoint _HingeJoint;
    [SerializeField] protected Rigidbody _Rid;

    [SerializeField] protected float _Spring_Value = 300f;

    [SerializeField] protected MinMaxPair _TargetRot;
    [SerializeField] protected MinMaxPair _LimitRot;

    [SerializeField] protected float forceStrength = 5f; // Lực đẩy tối đa

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
        Spring.spring = 300f;
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
        JointSpring Spring = this._HingeJoint.spring;
        Spring.targetPosition = this._TargetRot.Max;

        this._HingeJoint.spring = Spring;

        Invoke(nameof(this.DisableActionAfterTrip), 0.1f);
    }

    public virtual void DisableActionAfterTrip()
    {
        this.RemoveComponentsAvoidTripping();
        Destroy(this._Rid);

        this.gameObject.SetActive(false);
    }
    public virtual void DisableActionAfterDead()
    {
        this.RemoveComponentsAvoidTripping();

        // X và Z ngẫu nhiên nhỏ hơn, Y có giá trị lớn hơn
        Vector3 randomDirection = new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(0.8f, 1f), Random.Range(-0.5f, 0.5f)).normalized;

        // Add lực để vật thể văng ra
        this._Rid.AddForce(randomDirection * forceStrength, ForceMode.Impulse);

        //this.gameObject.SetActive(false);
    }

    protected virtual void RemoveComponentsAvoidTripping()
    {
        Destroy(this._HingeJoint);

        this._ObjectCtrl.ObjImpactOverall.gameObject.SetActive(false);
    }    
}

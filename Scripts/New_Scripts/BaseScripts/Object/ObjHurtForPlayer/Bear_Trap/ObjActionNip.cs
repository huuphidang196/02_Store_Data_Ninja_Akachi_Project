using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjActionNip : ObjActionHingeJoint
{
    [Header("ObjActionNip")]

    [SerializeField] protected float forceStrength = 5f; // Lực đẩy tối đa

    protected override void ResetValue()
    {
        base.ResetValue();

        JointSpring Spring = this._HingeJoint.spring;
        Spring.spring = 300f;
    }

    public override void SpringTarget()
    {
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

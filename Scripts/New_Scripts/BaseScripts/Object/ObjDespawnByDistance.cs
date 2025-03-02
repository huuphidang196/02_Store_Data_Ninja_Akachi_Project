using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjDespawnByDistance : ObjDespawn
{
    [Header("Despawn By Distance")]
    [SerializeField] protected Transform _Target;
    [SerializeField] protected float distance = 0f;

    [SerializeField] protected float distanceLimit = 30f;
    public float DistanceLimit => distanceLimit;

    protected override void OnEnable()
    {
        base.OnEnable();

        this.ReBorn();
    }

    protected virtual void ReBorn()
    {
        this.distance = 0;
    }

    protected virtual void SetTargetToReference(Transform Target)
    {
        this._Target = Target;
    }

    protected override void ResetValue()
    {
        base.ResetValue();

        this.ReBorn();
    }

    protected override bool CanDespawn()
    {
        // if (GameController.Instance.PauseGame) return false;

        this.distance = Vector2.Distance(this.GetPosOriginal(), this.GetPostionTarget());
        return this.PrequisiteBoolDistance();
    }

    protected virtual Vector2 GetPostionTarget()
    {
        return this._Target.position;
    }

    protected virtual Vector2 GetPosOriginal()
    {
        return transform.position;
    }

    protected virtual bool PrequisiteBoolDistance() => (this.distance > this.distanceLimit);
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObjectInLimits : ObjectAbstract
{
    [SerializeField] protected MinMaxPair _ValueTarget = new MinMaxPair(-25,205);
    [SerializeField] protected float _Timer = 0f;
    [SerializeField] protected float _Time_Rotate = 2f;
    [SerializeField] protected float _Time_Delay_Rotation = 0.3f;
    [SerializeField] protected float delayTimer = 0f;

    [SerializeField] protected Vector3 rotationAxis = Vector3.forward; // Z-axis (2D) — thay đổi nếu cần

    [SerializeField] protected bool rotatingToTarget = true;

    [SerializeField] protected bool isDelaying = false;

    protected virtual void FixedUpdate()
    {
        if (this.isDelaying)
        {
            this.delayTimer += Time.fixedDeltaTime;
            if (delayTimer >= this._Time_Delay_Rotation)
            {
                isDelaying = false;
                this.delayTimer = 0f;
                rotatingToTarget = !rotatingToTarget;
                this._Timer = 0f;
            }
            return;
        }

        this._Timer += Time.fixedDeltaTime;
        float t = Mathf.Clamp01(this._Timer / this._Time_Rotate);

        // Optional: Smooth easing
        float tSmooth = Mathf.SmoothStep(0f, 1f, t);

        float currentAngle = Mathf.Lerp(
            rotatingToTarget ? this._ValueTarget.Min : this._ValueTarget.Max,
            rotatingToTarget ? this._ValueTarget.Max : this._ValueTarget.Min,
            tSmooth
        );

       this._ObjectCtrl.transform.rotation = Quaternion.AngleAxis(currentAngle, rotationAxis);

        if (t >= 1f)
        {
            isDelaying = true;
        }
    }
}

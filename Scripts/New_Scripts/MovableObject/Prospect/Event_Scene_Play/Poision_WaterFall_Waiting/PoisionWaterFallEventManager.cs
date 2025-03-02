using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisionWaterFallEventManager : SurMonoBehaviour
{
    [SerializeField] protected List<ParticleSystem> _List_Poisions;
    [SerializeField] protected float _Timer = 0f;
    [SerializeField] protected float _Time_Interval = 5f;
    [SerializeField] protected float _Fade_Duration = 2f;  // Thời gian giảm emission về 0
    [SerializeField] protected bool isAlternating = true;  // Biến điều khiển trạng thái so le
    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadListPoision();
    }

    protected override void ResetValue()
    {
        base.ResetValue();

        this._Timer = 0f;
    }
    protected virtual void LoadListPoision()
    {
        if (this._List_Poisions.Count > 0) return;

        foreach (Transform item in this.transform)
        {
            ParticleSystem par = item.GetComponentInChildren<ParticleSystem>();
            if (par == null) continue;

            this._List_Poisions.Add(par);
        }
    }

    protected virtual void Update()
    {
        this._Timer += Time.deltaTime;

        if (this._Timer < this._Time_Interval) return;

        this._Timer = 0f;

        // Đảo trạng thái so le
        this.isAlternating = !this.isAlternating;

        // Bật/tắt theo trạng thái so le mới
        for (int i = 0; i < this._List_Poisions.Count; i++)
        {
            if ((i % 2 == 0 && isAlternating) || (i % 2 != 0 && !isAlternating))
            {
                this.SetEmissionRate(this._List_Poisions[i], 150);
                continue;
            }

            // Giảm emission về 0 trong vòng 2 giây
            StartCoroutine(this.FadeEmissionToZero(this._List_Poisions[i]));
        }
    }

    protected virtual void SetEmissionRate(ParticleSystem particleSystem, float rate)
    {
        var emission = particleSystem.emission;
        emission.rateOverTime = rate;
    }

    protected virtual IEnumerator FadeEmissionToZero(ParticleSystem particleSystem)
    {
        var emission = particleSystem.emission;
        float startRate = emission.rateOverTime.constant;
        float elapsedTime = 0f;

        while (elapsedTime < this._Fade_Duration)
        {
            float newRate = Mathf.Lerp(startRate, 0, elapsedTime / this._Fade_Duration);
            emission.rateOverTime = newRate;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Đảm bảo emission về đúng 0 sau khi kết thúc
        emission.rateOverTime = 0;
    }

    public virtual void SetActiveOrInActveAllWaterFall(bool active)
    {
        foreach (ParticleSystem item in this._List_Poisions)
        {
            item.gameObject.SetActive(active);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FadeInPlotSummary : SurMonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI textPlotSummary;
    protected float showDuration = 3f;
    protected float fadeDuration = 2f;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadTextPlotSummary();
    }

    protected virtual void LoadTextPlotSummary()
    {
        if (this.textPlotSummary != null) return;

        this.textPlotSummary = GetComponentInChildren<TextMeshProUGUI>();
        this.textPlotSummary.gameObject.SetActive(false);
    }

    protected override void Start()
    {
        this.textPlotSummary.gameObject.SetActive(true);
        StartCoroutine(ShowAndFade());
    }

    IEnumerator ShowAndFade()
    {
        // Hiển thị text (alpha = 1)
        Color color = textPlotSummary.color;
        color.a = 1f;
        textPlotSummary.color = color;

        // Chờ 3 giây
        yield return new WaitForSeconds(showDuration);

        // Mờ dần trong 2 giây
        float elapsed = 0f;
        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsed / fadeDuration);
            color.a = alpha;
            textPlotSummary.color = color;
            yield return null;
        }

        // Đảm bảo alpha = 0 sau khi mờ xong
        color.a = 0f;
        textPlotSummary.color = color;
    }
}

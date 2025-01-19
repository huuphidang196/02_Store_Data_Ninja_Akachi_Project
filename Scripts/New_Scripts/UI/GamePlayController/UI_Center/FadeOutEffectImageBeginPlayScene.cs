using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOutEffectImageBeginPlayScene : SurMonoBehaviour
{
    [SerializeField] protected GamePlayUICenter _GamePlayUICenter;
    [SerializeField] protected Image _Image_BG_Loading_Begin_Scene;
    [SerializeField] protected float _TimeDelay_Fadeout = 1f;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadGamePlayUICenter();
        this.LoadImageBGLoadingBeginScene();
    }

    protected virtual void LoadGamePlayUICenter()
    {
        if (this._GamePlayUICenter != null) return;

        this._GamePlayUICenter = transform.parent.GetComponent<GamePlayUICenter>();
    }

    protected override void ResetValue()
    {
        base.ResetValue();

        this._TimeDelay_Fadeout = this._GamePlayUICenter.GamePlayUIOverall.GamePlayConfigUIOverall.TimeDelay_Fadein;
        this._Image_BG_Loading_Begin_Scene.raycastTarget = false;
    }

    protected virtual void LoadImageBGLoadingBeginScene()
    {
        if (this._Image_BG_Loading_Begin_Scene != null) return;

        this._Image_BG_Loading_Begin_Scene = GetComponent<Image>();
    }
    protected override void Start()
    {
        this._Image_BG_Loading_Begin_Scene.enabled = true;
        // Bắt đầu fade-out khi chạy game
        if (this._Image_BG_Loading_Begin_Scene != null)
        {
            StartCoroutine(FadeOut(this._Image_BG_Loading_Begin_Scene, this._TimeDelay_Fadeout));
        }
    }

    private IEnumerator FadeOut(Image image, float duration)
    {
        // Lấy màu ban đầu của Image
        Color startColor = image.color;

        // Duyệt từ 1 (hoàn toàn hiển thị) xuống 0 (ẩn hoàn toàn)
        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            float normalizedTime = t / duration; // Phần trăm thời gian đã trôi qua
            image.color = new Color(startColor.r, startColor.g, startColor.b, 1 - normalizedTime);
            yield return null; // Chờ frame tiếp theo
        }

        // Đảm bảo alpha là 0 sau khi kết thúc
        image.color = new Color(startColor.r, startColor.g, startColor.b, 0);
        this.gameObject.SetActive(false);
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPlayFadeIn : SurMonoBehaviour
{
    [SerializeField] protected ButtonBackMainMenu _ButtonBackMainMenu;
    [SerializeField]
    protected Image _Image_Button_Play;
    public float duration = 2f; // Thời gian để hoàn tất hiệu ứng

    private float elapsedTime = 0f; // Thời gian đã trôi qua
    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadButtonBackMainMenu();
        this.LoadImageButtonPlay();
    }

 
    protected virtual void LoadButtonBackMainMenu()
    {
        if (this._ButtonBackMainMenu != null) return;

        this._ButtonBackMainMenu = GetComponent<ButtonBackMainMenu>();
    }

    protected virtual void LoadImageButtonPlay()
    {
        if (this._Image_Button_Play != null) return;

        this._Image_Button_Play = GetComponent<Image>();
    }

    protected override void ResetValue()
    {
        base.ResetValue();

        this._ButtonBackMainMenu.ButtonExect.enabled = false;
    }

    protected override void Start()
    {
        base.Start();

       
        Invoke(nameof(this.FadeInButtonPlay), this.duration);
    }

    protected virtual void FadeInButtonPlay()
    {
        this._ButtonBackMainMenu.ButtonExect.enabled = true;
    }    

    protected virtual void Update()
    {
        if (this.elapsedTime >= this.duration) return;

        this.elapsedTime += Time.deltaTime;

        // Tính toán alpha mới
        float newAlpha = Mathf.Clamp01(this.elapsedTime / this.duration);

        // Cập nhật màu của Sprite
        Color color = this._Image_Button_Play.color;
        color.a = newAlpha; // Giá trị alpha từ 0 đến 1
        this._Image_Button_Play.color = color;

    }

}

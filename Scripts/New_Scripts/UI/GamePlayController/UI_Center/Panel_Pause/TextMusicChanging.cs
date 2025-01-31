using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextMusicChanging : BaseText
{
    protected override void OnEnable()
    {
        base.OnEnable();

        GamePlayUIManager.Event_MusicChanging += this.ChangeTextMusic;
        this.ChangeTextMusic();
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        GamePlayUIManager.Event_MusicChanging -= this.ChangeTextMusic;
    }

    protected virtual void ChangeTextMusic()
    {
        bool onMusic = SystemController.Sys_Instance.SystemConfig.OnMusic;
        this.SetContent(onMusic ? "MUSIC : ON" : "MUSIC : OFF");
        this.SetTextToShow();
    }
}

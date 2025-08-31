using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextMusicChange : BaseText
{
    protected override void FixedUpdate()
    {
        this.ChangeTextMusic();
    }
    protected virtual void ChangeTextMusic()
    {
        bool onMusic = SystemController.Sys_Instance.SystemConfig.OnMusic;
        this.SetContent(onMusic ? "MUSIC : ON" : "MUSIC : OFF");
        this.SetTextToShow();
    }
}

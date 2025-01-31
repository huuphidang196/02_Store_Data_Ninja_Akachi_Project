using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerOverall : Singleton<SoundManagerOverall>
{
    [SerializeField] BGSoundRunTimeManager _BG_Sound_Scene_Play_Mode;
    public BGSoundRunTimeManager BG_Sound_Scene_Play_Mode => this._BG_Sound_Scene_Play_Mode;

    [SerializeField] BGSoundRunTimeManagerByOnlyTypeSound _BG_Sound_Adventure;
    public BGSoundRunTimeManagerByOnlyTypeSound BG_Sound_Adventure => this._BG_Sound_Adventure;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadSoundScenePlayMode();
        this.LoadSoundAdventure();
    }

 
    protected virtual void LoadSoundScenePlayMode()
    {
        if (this._BG_Sound_Scene_Play_Mode != null) return;

        this._BG_Sound_Scene_Play_Mode = transform.Find("Prospect_Sound_Scene_Play").Find("BG_Music").GetComponent<BGSoundRunTimeManager>();
    }

    protected virtual void LoadSoundAdventure()
    {
        if (this._BG_Sound_Adventure != null) return;

        this._BG_Sound_Adventure = transform.Find("Adventure_Sound").GetComponent<BGSoundRunTimeManagerByOnlyTypeSound>();
    }

}

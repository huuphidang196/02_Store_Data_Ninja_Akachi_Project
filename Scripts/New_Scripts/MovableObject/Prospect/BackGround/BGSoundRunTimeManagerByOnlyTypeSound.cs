using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGSoundRunTimeManagerByOnlyTypeSound : AudioRuntimeManager
{
    private static BGSoundRunTimeManagerByOnlyTypeSound _m_instance;

    [SerializeField] protected TypeProspectSound _Type_Sound_Selected_BG;
    [SerializeField] protected bool isSoundLevelMode;

    protected override void Awake()
    {
        base.Awake();

        if (_m_instance == null)
        {
            _m_instance = this;
            DontDestroyOnLoad(transform.parent);
            return;
        }

        Destroy(transform.parent);
    }
 
    protected override void LoadAudioSource()
    {
        base.LoadAudioSource();
        this._AudioSource.volume = 1f;
    }

    protected override AudioClip GetAudioClipRuntime()
    {
        return SystemController.Sys_Instance.SystemConfig.SoundCtrlSO.SoundProspectSO.GetAudioClipByNameTypeProspectSound(this._Type_Sound_Selected_BG);
    }

    protected override void FixedUpdate()
    {
        if (this.GetNameSceneCurrent().Contains("Level_") != this.isSoundLevelMode)
        {
            this._AudioSource.Stop();
            return;
        }

        base.FixedUpdate();
    }

    protected virtual string GetNameSceneCurrent()
    {
        return SceneManager.GetActiveScene().name;
    }
}

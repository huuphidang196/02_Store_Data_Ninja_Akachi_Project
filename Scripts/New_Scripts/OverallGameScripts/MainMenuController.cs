using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : SystemController
{
    private static MainMenuController m_instance;
    public static MainMenuController Instance => m_instance;

    protected override void Awake()
    {
        base.Awake();

        if (m_instance != null) Debug.LogError("Allow only MainMenuController has been exist");

        m_instance = this;
    }

    public virtual void ChangeStatusOnOffMusic()
    {
        bool onMusic = SystemController.Sys_Instance.SystemConfig.OnMusic;
        SystemController.Sys_Instance.SystemConfig.OnMusic = !onMusic;
    }
}

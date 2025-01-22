using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


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
    protected override void Start()
    {
        base.Start();

        this.LoadGameBySetDataSO();
    }

    protected virtual void LoadGameBySetDataSO()
    {
        SaveData saveData = SaveManager.Instance.DataSaved;

        if (saveData)
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}

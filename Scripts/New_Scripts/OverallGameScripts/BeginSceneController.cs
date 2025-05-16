using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginSceneController : SystemController
{
    private static BeginSceneController m_instance;
    public static BeginSceneController Instance => m_instance;

    protected override void Awake()
    {
        base.Awake();

        if (m_instance != null) Debug.LogError("Allow only BeginSceneController  been exist");

        m_instance = this;
    }
  
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMenuController : SystemController
{
    private static ShopMenuController m_instance;
    public static ShopMenuController Instance => m_instance;

    protected override void Awake()
    {
        base.Awake();

        if (m_instance != null) Debug.LogError("Allow only ShopMenuController has been exist");

        m_instance = this;
    }
}
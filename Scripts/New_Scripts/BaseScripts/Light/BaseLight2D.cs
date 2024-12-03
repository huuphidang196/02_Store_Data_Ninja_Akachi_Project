using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal; // Import thư viện để sử dụng Light2D

public class BaseLight2D : ObjectAbstract
{
    [SerializeField] protected Light2D _Light2D;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadLight2D();
    }

    protected virtual void LoadLight2D()
    {
        if (this._Light2D != null) return;

        this._Light2D = GetComponent<Light2D>();
    }
}

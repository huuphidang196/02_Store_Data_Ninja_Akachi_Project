using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRespawnTower : BaseLight2D
{
    [Header("LightRespawnTower")]
    [SerializeField] protected float _On_Intensity = 0.7f;
    [SerializeField] protected bool wasTurned = false;

    protected override void ResetValue()
    {
        base.ResetValue();

        this.wasTurned = false;
    }

    protected override void LoadLight2D()
    {
        base.LoadLight2D();

        this._Light2D.intensity = 0f;
    }

    protected virtual void FixedUpdate()
    {
        if (this.wasTurned) return;

        this.wasTurned = PlayerCtrl.Instance.transform.position.x > this._ObjectCtrl.transform.position.x;
        this._Light2D.intensity = (this.wasTurned) ? this._On_Intensity : 0f;
    }    
}

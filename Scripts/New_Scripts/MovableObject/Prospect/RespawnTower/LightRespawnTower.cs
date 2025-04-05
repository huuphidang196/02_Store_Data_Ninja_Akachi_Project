using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRespawnTower : BaseLight2D
{
    [Header("LightRespawnTower")]
    [SerializeField] protected float _On_Intensity = 0.7f;
    [SerializeField] protected bool wasTurned = false;
    public bool WasTurned => this.wasTurned;

    [SerializeField] protected Transform _VFX_SpawnPoint;
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

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadVFXSpawnPoint();
    }

    protected virtual void LoadVFXSpawnPoint()
    {
        if (this._VFX_SpawnPoint != null) return;

        this._VFX_SpawnPoint = transform.Find("VFX_Spawn_Point");
        this._VFX_SpawnPoint.gameObject.SetActive(false);
    }

    protected virtual void FixedUpdate()
    {
        if (this.wasTurned) return;

        this.wasTurned = this.GetConditionTurning();

        this._Light2D.intensity = (this.wasTurned) ? this._On_Intensity : 0f;
        this._VFX_SpawnPoint.gameObject.SetActive(this.wasTurned);
    }

    protected virtual bool GetConditionTurning()
    {
        return PlayerCtrl.Instance.transform.position.x - this._ObjectCtrl.transform.position.x > 1f &&
              PlayerCtrl.Instance.transform.position.x - this._ObjectCtrl.transform.position.x < 1.5f &&
                Mathf.Abs(PlayerCtrl.Instance.transform.position.y - this._ObjectCtrl.transform.position.y) < 3f;
    }
}

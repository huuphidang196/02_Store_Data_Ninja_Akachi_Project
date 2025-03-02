using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjDespawnParentByDistanceFollowCamera : ObjDespawnByDistance
{
    [SerializeField] protected Transform _Parent_Desapawn;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadStoneScrollEvents();
    }

    protected virtual void LoadStoneScrollEvents()
    {
        if (this._Parent_Desapawn != null) return;

        this._Parent_Desapawn = transform.parent;
    }

    protected override float GetDistanceLimit() => 30f;
   
    protected override void Start()
    {
        base.Start();

        Transform camera_Main = CameraFollowTarget.Instance.transform;
        this.SetTargetToReference(camera_Main);
    }

    public override void DespawnObject()
    {
        this._Parent_Desapawn.gameObject.SetActive(false);
    }
}

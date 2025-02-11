using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneScrollEventsDespawnByDistance : ObjDespawnByDistance
{
    [SerializeField] protected Transform _Stone_Scroll_Events;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadStoneScrollEvents();
    }

    protected virtual void LoadStoneScrollEvents()
    {
        if (this._Stone_Scroll_Events != null) return;

        this._Stone_Scroll_Events = transform.parent;
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
        this._Stone_Scroll_Events.gameObject.SetActive(false);
    }
}

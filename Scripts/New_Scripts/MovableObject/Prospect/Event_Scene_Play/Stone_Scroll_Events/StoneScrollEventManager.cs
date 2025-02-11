using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneScrollEventManager : EventScenePlayAutoOnByDistancePlayer
{
    [SerializeField] protected Transform _Stone_Scroll_Events;

    protected override void ResetValue()
    {
        base.ResetValue();

        this.activationDistance = 27f;
    }
    protected override void ConductActionEvents()
    {
        if (this._Stone_Scroll_Events == null) return;

        this._Stone_Scroll_Events.gameObject.SetActive(true);
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadStoneScrollEvents();
    }

    protected virtual void LoadStoneScrollEvents()
    {
        if (this._Stone_Scroll_Events != null) return;

        this._Stone_Scroll_Events = transform.Find("Stone_Scroll_Events");
    }
}

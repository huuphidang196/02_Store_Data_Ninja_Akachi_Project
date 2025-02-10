using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanceTrapEventCtrl : ObjectCtrl
{
    [SerializeField] protected LanceTrapEventsAutoOn _LanceTrapEventsAutoOn;
    public LanceTrapEventsAutoOn LanceTrapEventsAutoOn => this._LanceTrapEventsAutoOn;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadSoundLanceTrapEventsAutoOn();
    }

    protected virtual void LoadSoundLanceTrapEventsAutoOn()
    {
        if (this._LanceTrapEventsAutoOn != null) return;

        this._LanceTrapEventsAutoOn = transform.GetComponentInChildren<LanceTrapEventsAutoOn>();
    }

}

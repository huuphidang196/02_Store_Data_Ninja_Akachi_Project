using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(EventTrigger))]
public class BaseButtonControlMovementPlayer : BaseButton
{
    [SerializeField]
    protected EventTrigger _Event_Trigger;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadEvenTrigger();
    }

    protected virtual void LoadEvenTrigger()
    {
        if (this._Event_Trigger != null) return;

        this._Event_Trigger = gameObject.GetComponent<EventTrigger>();
    }

    protected override void Start()
    {
        base.Start();

        // Thêm sự kiện PointerDown
        EventTrigger.Entry pointerDownEntry = new EventTrigger.Entry();
        pointerDownEntry.eventID = EventTriggerType.PointerDown;
        pointerDownEntry.callback.AddListener((data) => { this.OnButtonDown(); });
        _Event_Trigger.triggers.Add(pointerDownEntry);

        // Thêm sự kiện PointerUp
        EventTrigger.Entry pointerUpEntry = new EventTrigger.Entry();
        pointerUpEntry.eventID = EventTriggerType.PointerUp;
        pointerUpEntry.callback.AddListener((data) => { this.OnButtonUp(); });
        _Event_Trigger.triggers.Add(pointerUpEntry);
    }

    protected virtual void OnButtonDown()
    {

    }
    protected virtual void OnButtonUp()
    {

    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayUIBelow : GamePlayUIOverallAbstract
{
    [SerializeField] protected Transform _UI_Below_Center;
    public Transform UI_Below_Center => this._UI_Below_Center;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadUIBelowCenter();
    }

    protected virtual void LoadUIBelowCenter()
    {
        if (this._UI_Below_Center != null) return;

        this._UI_Below_Center = transform.Find("UI_Below_Center");
        this._UI_Below_Center.gameObject.SetActive(false);
    }

    protected override void Start()
    {
        base.Start();

        GamePlayUIManager.Event_HideAllUIButton += this.IsHidenALlChildUIBelow;
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        GamePlayUIManager.Event_HideAllUIButton -= this.IsHidenALlChildUIBelow;
    }

    protected virtual void FixedUpdate()
    {
        if (!PlayerCtrl.Instance.PlayerDamReceiver.ObjIsDead) return;

        this.IsHidenALlChildUIBelow(false);
    }

    protected virtual void IsHidenALlChildUIBelow()
    {
        this.IsHidenALlChildUIBelow(!GamePlayUIManager.Instance.IsHidenUI);
    }

    protected virtual void IsHidenALlChildUIBelow(bool active)
    {
        // if (!GamePlayUIManager.Instance.IsHidenUI) return;

        if (!active != transform.GetChild(0).gameObject.activeInHierarchy) return;

        foreach (Transform item in this.transform)
        {
            if (item.GetSiblingIndex() == this._UI_Below_Center.GetSiblingIndex()) continue;
            item.gameObject.SetActive(active);
        }
    }
}

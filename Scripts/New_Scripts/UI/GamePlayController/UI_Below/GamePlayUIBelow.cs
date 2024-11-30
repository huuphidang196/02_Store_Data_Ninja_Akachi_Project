using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayUIBelow : GamePlayUIOverallAbstract
{
    //protected virtual void FixedUpdate()
    //{
    //    this.IsHidenALlChildUIBelow();
    //}
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
            item.gameObject.SetActive(active);
        }
    }
}

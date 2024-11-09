using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayUIAbove : GamePlayUIOverallAbstract
{
    [SerializeField] protected Transform _UI_Above_Left;
    public Transform UI_Above_Left => this._UI_Above_Left;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadUIAboveLeft();
    }

    protected virtual void LoadUIAboveLeft()
    {
        if (this._UI_Above_Left != null) return;

        this._UI_Above_Left = transform.Find("UI_Above_Left").transform;
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

    protected virtual void IsHidenALlChildUIBelow()
    {
        if (GamePlayUIManager.Instance.IsHidenUI != this._UI_Above_Left.gameObject.activeInHierarchy) return;

        this._UI_Above_Left.gameObject.SetActive(!GamePlayUIManager.Instance.IsHidenUI);

    }
}


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayUIOverallAbstract : SurMonoBehaviour
{
    [SerializeField] protected GamePlayUIOverall _GamePlayUIOverall;
    public GamePlayUIOverall GamePlayUIOverall => this._GamePlayUIOverall;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadGamePlayUIOverall();
    }

    protected virtual void LoadGamePlayUIOverall()
    {
        if (this._GamePlayUIOverall != null) return;

        this._GamePlayUIOverall = GetComponentInParent<GamePlayUIOverall>();
    }
}

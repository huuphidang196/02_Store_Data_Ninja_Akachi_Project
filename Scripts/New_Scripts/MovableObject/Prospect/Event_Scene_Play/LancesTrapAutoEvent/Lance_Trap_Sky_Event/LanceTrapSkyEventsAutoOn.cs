using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanceTrapSkyEventsAutoOn : LanceTrapEventsAutoOn
{
    protected override Vector3 GetOffSetSpawnVFX(Transform lance)
    {
        return 2f * lance.up;
    }

    protected override void LoadLanceObjects()
    {
        //Beacause resetvalue after loadcom
        this.raiseHeight = 15f;

        base.LoadLanceObjects();
        this.LoadStartAndTargetPos();
        this.activationDistance = 2f;
    }
    protected virtual void LoadStartAndTargetPos()
    {
        if (this._LanceObjects.Count == 0) return;

        this._StartPositions.Clear();
        this._TargetPositions.Clear();

        for (int i = 0; i < this._LanceObjects.Count; i++)
        {
            this._TargetPositions.Add(this._LanceObjects[i].transform.position);
            this._StartPositions.Add(this._LanceObjects[i].transform.position - this.raiseHeight * this._LanceObjects[i].transform.up);
        }
    }

    protected override void Start()
    {
        base.Start();

        for (int i = 0; i < this._LanceObjects.Count; i++)
        {
            this._LanceObjects[i].transform.position = this._StartPositions[i];
        }
    }

}

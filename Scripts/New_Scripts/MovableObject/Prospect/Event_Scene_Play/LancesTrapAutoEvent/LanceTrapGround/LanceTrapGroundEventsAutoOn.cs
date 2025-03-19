using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanceTrapGroundEventsAutoOn : LanceTrapEventsAutoOn
{
    protected override void ResetValue()
    {
        base.ResetValue();

        this.activationDistance = 5f;
    }

    protected override Vector3 GetOffSetSpawnVFX(Transform lance)
    {
        return 2f * Vector3.down;
    }

    protected override void LoadLanceObjects()
    {
        base.LoadLanceObjects();

        this._StartPositions.Add(this._LanceObjects[0].transform.position);
        this._TargetPositions.Add(
               new Vector3(this._LanceObjects[0].transform.position.x, this.transform.GetChild(this.transform.childCount - 1).position.y + raiseHeight, 0));

        for (int i = 1; i < this._LanceObjects.Count; i++)
        {
            this._LanceObjects[i].transform.position =
                new Vector3(this._LanceObjects[i - 1].transform.position.x - 0.5f, this._LanceObjects[i].transform.position.y, 0);
            this._StartPositions.Add(this._LanceObjects[i].transform.position);
            this._TargetPositions.Add(
                new Vector3(this._LanceObjects[i].transform.position.x, this.transform.GetChild(this.transform.childCount - 1).position.y + raiseHeight, 0));
        }
    }


    
}


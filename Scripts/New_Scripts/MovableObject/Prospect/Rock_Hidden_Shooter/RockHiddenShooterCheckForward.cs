using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockHiddenShooterCheckForward : CharacterCheckForward
{
    protected override void ResetValue()
    {
        this.LoadLayerMaskForward();

        this._Length_Raycast = 15f;
    }

    protected override void LoadLayerMaskForward()
    {
        if (this._ObjForwardLayer.Length > 0) return;

        this._ObjForwardLayer = new string[1];
        this._ObjForwardLayer[0] = "Player";
    }
    protected override void FixedUpdate()
    {
        this.ProcessFixedUpdateEvent();
    }
    protected override Vector2 GetDirectionRaycast()
    {
        return this.transform.right * this._Length_Raycast;
    }
}

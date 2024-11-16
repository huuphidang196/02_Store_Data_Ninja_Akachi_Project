using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjDeadByDistance : ObjDespawnByDistance
{
    public PlayerCtrl PlayerCtrl => this._ObjectCtrl as PlayerCtrl;

    protected override float GetDistanceLimit() => 50f;

    protected override void Start()
    {
        base.Start();

        Transform camera_Main = CameraFollowTarget.Instance.transform;
        this.SetTargetToReference(camera_Main);
    }

    public override void DespawnObject()
    {
        if (this.PlayerCtrl.PlayerDamReceiver.ObjIsDead) return;

        if (InputManager.Instance.IsRiviving) return;
        //Call to overall despawn
        this.PlayerCtrl.PlayerDamReceiver.DeductHP(99999f);
    }
}

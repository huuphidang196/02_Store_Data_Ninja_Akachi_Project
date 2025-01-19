using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjDeadByDistance : ObjDespawnByDistance
{
    public PlayerCtrl PlayerCtrl => this._ObjectCtrl as PlayerCtrl;

    protected override float GetDistanceLimit() => 20f;

    protected override void Start()
    {
        base.Start();

        Transform camera_Main = CameraFollowTarget.Instance.transform;
        this.SetTargetToReference(camera_Main);
    }

    protected override Vector2 GetPostionTarget()
    {
        Vector2 target = new Vector2(0, base.GetPostionTarget().y);

        return target;
    }

    protected override Vector2 GetPosOriginal()
    {
        Vector2 pos = new Vector2(0, transform.position.y);

        return pos;
    }
    public override void DespawnObject()
    {
        if (this.PlayerCtrl.PlayerDamReceiver.ObjIsDead) return;

        if (InputManager.Instance.IsRiviving) return;
        //Call to overall despawn
        this.PlayerCtrl.PlayerDamReceiver.DeductHP(99999f);
    }
}

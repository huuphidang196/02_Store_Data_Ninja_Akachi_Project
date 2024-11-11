using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneCanBrokeDamReceiver : ObjDamageReceiver
{
    protected StoneCanBrokeCtrl _StoneCanBrokeCtrl => this._ObjectCtrl as StoneCanBrokeCtrl;

    protected override void LoadColliderObject()
    {
        base.LoadColliderObject();
        this._BoxCollider2D.enabled = true;
    }

    protected override float GetMaxHP()
    {
        return 2f;
    }

    public override void DeductHP(float damage)
    {
        base.DeductHP(damage);

        // Animation
        this._StoneCanBrokeCtrl.StoneCanBrokeModel.SetSpriteIsAttacked(false);
    }

    protected override void OnDead()
    {
        //Disable Image Model

        Invoke(nameof(this.DespawnStoneCanBroke), 0.5f);
    }

    protected virtual void DespawnStoneCanBroke()
    {
        //Holder
        //ProspectObjectSpawner.Instance.Despawn(this.ObjectCtrl.transform);

        //Disable Collider
        this._BoxCollider2D.enabled = false;
    }    
}

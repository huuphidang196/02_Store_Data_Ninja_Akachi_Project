using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamReceiver : ObjDamageReceiver
{
    public PlayerCtrl PlayerCtrl => this._ObjectCtrl as PlayerCtrl;

    protected override void Start()
    {
        base.Start();

        this.IgnoreLayerCollisionOfPlayerObject("Player", "Enemy", true);
        this.IgnoreLayerCollisionOfPlayerObject("Player", "Item", true);
        this.IgnoreLayerCollisionOfPlayerObject("Player", "ObjInteractableShuriken", true);

    }
    protected override float GetMaxHP()
    {
        return 1;// Load from Scriptable Object
    }
    protected override void OnDead()
    {
        this.PlayerCtrl.PlayerObjDead.EventPlayerDead();

        InputManager.Instance.SetFalseAllBoolWhenPlayerDead();
        //  Debug.Log("Player Dead");

        this.ChangeLayerPlayerByName("Default");
        this.PlayerCtrl.PlayerMovement.Rigidbody2D.gravityScale = 10f;

    }

    public virtual void RiviveCharacter()
    {
       // Debug.Log("Rivival");
        this.ReBorn();
        this.ChangeLayerPlayerByName("Player");
        this.PlayerCtrl.PlayerMovement.Rigidbody2D.gravityScale = 3f;

    }

    public override void DeductHP(float damage)
    {
        if (this.PlayerCtrl.PlayerMovement.IsDashing) return;

        base.DeductHP(damage);
    }

    public virtual void ChangeLayerPlayerByName(string nameNewLayer)
    {
        this.PlayerCtrl.gameObject.layer = LayerMask.NameToLayer(nameNewLayer);
        this.gameObject.layer = LayerMask.NameToLayer(nameNewLayer);
        this.PlayerCtrl.PlayerLooter.gameObject.layer = LayerMask.NameToLayer(nameNewLayer);
        //// Đổi layer cho tất cả các object con
        //foreach (Transform child in this.PlayerCtrl.transform)
        //{
        //    child.gameObject.layer = LayerMask.NameToLayer(nameNewLayer);

        //}
    }
    public virtual void IgnoreLayerCollisionOfPlayerObject(string layer_01, string layer_02, bool isInorged)
    {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer(layer_01), LayerMask.NameToLayer(layer_02), isInorged);
    }    

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamReceiver : ObjDamageReceiver
{
    public PlayerCtrl PlayerCtrl => this._ObjectCtrl as PlayerCtrl;

    protected override void Start()
    {
        base.Start();

        this.SetIgnoreCollision();       
    }

    protected virtual void SetIgnoreCollision()
    {
        this.IgnoreLayerCollisionOfPlayerObject("Player", "Enemy", true);
        this.IgnoreLayerCollisionOfPlayerObject("Player", "Item", true);
        this.IgnoreLayerCollisionOfPlayerObject("Player", "ObjInteractableShuriken", true);

        // Ignore với tất cả các layer khác
        int totalLayers = 32; // Unity hỗ trợ tối đa 32 layer
        for (int i = 0; i < totalLayers; i++)
        {
            if (i != LayerMask.NameToLayer("Ground") && i != LayerMask.NameToLayer("PlayerDead"))
            {
                Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("PlayerDead"), i, true);
            }
        }

        this.IgnoreLayerCollisionOfPlayerObject("PlayerHiddenMode", "Item", true);
        this.IgnoreLayerCollisionOfPlayerObject("PlayerHiddenMode", "ItemLootable", true);     
    }

    protected override float GetMaxHP()
    {
        return 1;// Load from Scriptable Object
    }
    protected override void OnDead()
    {
        this.PlayerCtrl.PlayerObjDead.EventPlayerDead();

        InputManager.Instance.SetFalseAllBoolWhenPlayerDead();
       
        this.ChangeLayerPlayerByName("PlayerDead");

    }

    public virtual void RiviveCharacter()
    {
       // Debug.Log("Rivival");
        this.ReBorn();
        this.ChangeLayerPlayerByName("Player");
        this.PlayerCtrl.PlayerMovement.Rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        Invoke(nameof(this.SetOffRiviving), 3f);
    }

    protected virtual void SetOffRiviving()
    {
        InputManager.Instance.PlayerRiviveAgainCompleted();
    }    

    public virtual void ChangeLayerPlayerByName(string nameNewLayer)
    {
        this.PlayerCtrl.gameObject.layer = LayerMask.NameToLayer(nameNewLayer);
        this.gameObject.layer = LayerMask.NameToLayer(nameNewLayer);
        this.PlayerCtrl.PlayerLooter.gameObject.layer = LayerMask.NameToLayer(nameNewLayer);
      
    }
 
    protected virtual void SetEnableColliderPlayer(bool playerRivival)
    {
        this._BoxCollider2D.enabled = playerRivival;
        this.PlayerCtrl.PlayerLooter.BoxCollider2D.enabled = playerRivival;
    }    
}

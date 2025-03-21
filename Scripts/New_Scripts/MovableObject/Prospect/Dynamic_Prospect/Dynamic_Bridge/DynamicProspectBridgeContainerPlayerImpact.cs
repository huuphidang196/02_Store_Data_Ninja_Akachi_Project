using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicProspectBridgeContainerPlayerImpact : DynamicProspectImpact
{
    [SerializeField] protected bool Test_parent_null;
    [SerializeField] protected bool Test_parent_diff;
    protected override void OnTriggerEnter2D(Collider2D collider2D)
    {
        base.OnTriggerEnter2D(collider2D);

        if (this.GetParent(collider2D.gameObject).gameObject.layer != LayerMask.NameToLayer("Player")) return;

        //Notify to Container
        this.DynamicMovementCtrl.DynamicProspectContainerPlayer.ContainPlayerBecomeParent(PlayerCtrl.Instance.transform);
    }

    protected virtual void OnTriggerExit2D(Collider2D collision)
    {
        if (this.GetParent(collision.gameObject).gameObject.layer != LayerMask.NameToLayer("Player")) return;

        this.DynamicMovementCtrl.DynamicProspectContainerPlayer.DetachedPlayerBecomeSeperatedObject(PlayerCtrl.Instance.transform);
    }

    protected virtual void Update()
    {
        this.Test_parent_null = PlayerCtrl.Instance.transform.parent == null;
        this.Test_parent_diff = PlayerCtrl.Instance.transform.parent != this.transform;
        if (PlayerCtrl.Instance.transform.parent == null) return;

        if (PlayerCtrl.Instance.transform.parent != this.DynamicMovementCtrl.DynamicProspectContainerPlayer.transform) return;

        PlayerCtrl.Instance.PlayerMovement.Rigidbody2D.bodyType = this.CheckPlayerHasAction() ? RigidbodyType2D.Dynamic : RigidbodyType2D.Kinematic;
    }

    protected virtual bool CheckPlayerHasAction()
    {
        if (PlayerCtrl.Instance.PlayerMovement.Move_Left || PlayerCtrl.Instance.PlayerMovement.Move_Right) return true;

        if (PlayerCtrl.Instance.PlayerMovement.First_Jump) return true;

        if (PlayerCtrl.Instance.PlayerMovement.IsDashing) return true;

        return false;
    }
}
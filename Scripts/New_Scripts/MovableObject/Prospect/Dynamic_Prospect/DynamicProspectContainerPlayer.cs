using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicProspectContainerPlayer : DynamicMovementAbstract
{
    public virtual void ContainPlayerBecomeParent(Transform player)
    {
        if (player.name != PlayerCtrl.Instance.gameObject.name) return;

        player.SetParent(this.transform);
    }

    public virtual void DetachedPlayerBecomeSeperatedObject(Transform player)
    {
        if (player.name != PlayerCtrl.Instance.gameObject.name) return;

        player.SetParent(null);
        PlayerCtrl.Instance.PlayerMovement.Rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
    }
}

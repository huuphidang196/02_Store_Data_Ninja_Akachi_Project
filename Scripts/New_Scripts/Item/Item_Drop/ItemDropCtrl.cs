using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class MinMaxPair
{
    public float Min;
    public float Max;

    public MinMaxPair(float min, float max)
    {
        this.Min = min;
        this.Max = max;
    }
}

[RequireComponent(typeof(Rigidbody2D))]

public class ItemDropCtrl : ObjectCtrl
{
    public ItemDamReceiver ItemDamReceiver => this._ObjDamageReceiver as ItemDamReceiver;

    [SerializeField] protected ItemSoundManager _ItemSoundManager;
    public ItemSoundManager ItemSoundManager => this._ItemSoundManager;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadItemSoundManager();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        this.DisableManyObject(null, true);
    }

    protected virtual void LoadItemSoundManager()
    {
        if (this._ItemSoundManager != null) return;

        this._ItemSoundManager = GetComponentInChildren<ItemSoundManager>();
    }

    public virtual void DisableAllObjectExcludeSoundManager()
    {
        this.DisableManyObject(this._ItemSoundManager.transform, false);
    }

    protected virtual void DisableManyObject(Transform objExclude, bool active)
    {
        foreach (Transform item in this.transform)
        {
            if (objExclude != null && item == objExclude)
            {
                item.gameObject.SetActive(!active);
                continue;
            }

            item.gameObject.SetActive(active);
        }
    }
}

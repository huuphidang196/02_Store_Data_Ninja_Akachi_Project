using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class ItemLootableDamReceiver : ItemDamReceiver
{
    [SerializeField] protected ItemDropUnit _ItemDropUnit;
    public ItemDropUnit ItemDropUnit => this._ItemDropUnit;

    protected override void Start()
    {
        base.Start();
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("WeaponPlayer"), LayerMask.NameToLayer("ItemLootable"), true);
    }

    protected override void OnDead()
    {
        this.SpawnMoneyBag();
        base.OnDead();
    }

    protected virtual void SpawnMoneyBag()
    {
        //Spawn text
        Transform textMoney = ItemDropSpawner.Instance.Spawn(ItemDropSpawner.Name_Text_Fly,
            this._ObjectCtrl.transform.position, Quaternion.identity);

        TextUICtrl textUICtrl = textMoney.GetComponent<TextUICtrl>();
        //Set Content value
        textUICtrl.TextDescription.SetContentAndColor(this._ItemDropUnit.ItemUnit);

        textMoney.gameObject.name = ItemDropSpawner.Name_Text_Fly;
        textMoney.localScale = Vector3.one;
        textMoney.gameObject.SetActive(true);

    }

    //public virtual float GetValueItemDrop()
    //{

    //}
}

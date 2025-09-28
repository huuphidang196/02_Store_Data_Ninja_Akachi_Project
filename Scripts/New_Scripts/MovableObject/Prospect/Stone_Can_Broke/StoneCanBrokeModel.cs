using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneCanBrokeModel : StoneCanBrokeAbstract
{
    [SerializeField] protected SpriteRenderer _SpriteRenderer_Model;

    [SerializeField] protected Sprite _Sprite_Normal;
    [SerializeField] protected Sprite _Sprite_Is_Attacked;

    protected override void OnEnable()
    {
        base.OnEnable();

        this._SpriteRenderer_Model.enabled = true;
    }
    protected override void Start()
    {
        base.Start();

        this.SetSpriteIsAttacked(true);
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadSpriteRenderer();
    }

    protected virtual void LoadSpriteRenderer()
    {
        if (this._SpriteRenderer_Model != null) return;

        this._SpriteRenderer_Model = GetComponent<SpriteRenderer>();
    }

    public virtual void SetSpriteIsAttacked(bool isNormal)
    {
        this._SpriteRenderer_Model.sprite = isNormal ? this._Sprite_Normal : this._Sprite_Is_Attacked;
    }

    //protected virtual void Update()
    //{
    //    if (!this._StoneCanBrokeCtrl.StoneCanBrokeDamReceiver.ObjIsDead) return;

    //    this._SpriteRenderer_Model.enabled = false;
    //}    
}

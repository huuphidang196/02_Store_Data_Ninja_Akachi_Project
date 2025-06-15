using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManagerBoss : SurMonoBehaviour
{
    [SerializeField] protected BossCtrl _BossCtrl;

    //Configuration
    ///Number Data
    [SerializeField] protected float _Limit_Space_Pos_X = 20f;

    [SerializeField] protected float _Distance_OnMode_ShadowStep = 8f;
    [SerializeField] protected float _Limit_Space_Shadow_Pos_X = 10f;
    public float Distance_MoveShadow_Axis_X => 7f;

    [SerializeField] protected float _Distance_OnMode_FlowDark = 2f;
    [SerializeField] protected float _Limit_Space_Flow_Pos_X = 12f;
    public float Distance_MoveFlow_Axis_X => 6f;


    [SerializeField] protected float _Distance_Attack_Slash = 5f;

    [SerializeField] protected float _Distance_OnMode_Jump_Attack = 7f;
    [SerializeField] protected float _Limit_Space_Jump_Pos_X = 11f;
    public float Distance_MoveJump_Axis_X => 7;//must == distanceOnMode

    [SerializeField] protected float _Distance_Recovery_Attack = 2;//seconds;

    [SerializeField] protected bool isShadow = false;
    [SerializeField] protected bool isFlowDark = false;
    [SerializeField] protected bool isAttackSlash = false;
    [SerializeField] protected bool isJumpAttack = false;
    //move left or right movement decide

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadBossCtrl();
    }

    protected virtual void LoadBossCtrl()
    {
        if (this._BossCtrl != null) return;

        this._BossCtrl = GetComponentInParent<BossCtrl>();
    }

    protected virtual void Update()
    {
        this.isFlowDark = this.GetDistanceX() <= this._Distance_OnMode_FlowDark && this.CheckInsideScope(this._Limit_Space_Flow_Pos_X);

        this.isAttackSlash = this.GetDistanceX() <= this._Distance_Attack_Slash && !this.isFlowDark;

        this.isJumpAttack = !this.isFlowDark && !this.isAttackSlash && this.GetDistanceX() <= this._Distance_OnMode_Jump_Attack && this.CheckInsideScope(this._Limit_Space_Jump_Pos_X);

        this.isShadow = !this.isFlowDark && !this.isAttackSlash && !this.isJumpAttack && this.GetDistanceX() <= this._Distance_OnMode_ShadowStep && this.CheckInsideScope(this._Limit_Space_Shadow_Pos_X);

    }
    protected virtual float GetDistanceX()
    {
        return Mathf.Abs(PlayerCtrl.Instance.gameObject.transform.position.x - this._BossCtrl.transform.position.x);
    }

    protected virtual bool CheckInsideScope(float limit)
    {
        return Mathf.Abs(this._BossCtrl.transform.position.x) <= limit;
    }
}

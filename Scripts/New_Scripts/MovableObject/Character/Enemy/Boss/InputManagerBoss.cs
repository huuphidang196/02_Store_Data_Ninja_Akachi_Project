using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManagerBoss : SurMonoBehaviour
{
    [SerializeField] protected BossCtrl _BossCtrl;

    //Configuration
    ///Number Data
    [SerializeField] protected float _Limit_Space_Pos_X = 23f;

    [SerializeField] protected float _Distance_OnMode_ShadowStep = 11f;
    [SerializeField] protected float _Limit_Space_Shadow_Pos_X = 13f;
    public float Distance_MoveShadow_Axis_X => 11f;

    [SerializeField] protected float _Distance_OnMode_FlowDark = 3f;
    [SerializeField] protected float _Limit_Space_Flow_Pos_X = 15f;
    public float Distance_MoveFlow_Axis_X => 9f;


    [SerializeField] protected float _Distance_Attack_Slash = 7f;

    [SerializeField] protected float _Distance_OnMode_Jump_Attack = 10f;
    [SerializeField] protected float _Limit_Space_Jump_Pos_X = 14f;
   // public float Distance_MoveJump_Axis_X => 10;//must == distanceOnMode

    [SerializeField] protected float _Time_Recovery_Attack = 5;//seconds;

    [SerializeField] protected bool isBeginFighter = false;
    public bool IsBeginFighter => this.isBeginFighter;

    [SerializeField] protected float _Time_Player_Recognize = 8f;//seconds;
    public float Time_Player_Recognize => this._Time_Player_Recognize;

    [SerializeField] protected bool isShadow = false;
    public bool IsShadow => this.isShadow;

    [SerializeField] protected bool isFlowDark = false;
    public bool IsFlowDark => this.isFlowDark;

    [SerializeField] protected bool isAttackSlash = false;
    public bool IsAttackSlash => this.isAttackSlash;

    [SerializeField] protected bool isJumpAttack = false;
    public bool IsJumpAttack => this.isJumpAttack;

    [SerializeField] protected bool isCoolAttack = false;
    public bool IsCoolAttack => this.isCoolAttack;
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

    protected override void Start()
    {
        base.Start();

        Invoke(nameof(this.SetBeginFighter), this._Time_Player_Recognize);
    }

    protected virtual void SetBeginFighter()
    {
        this.isBeginFighter = true;
    }

    protected virtual void Update()
    {
        if (!this.isBeginFighter) return;

        this.isFlowDark = this.GetDistanceX() <= this._Distance_OnMode_FlowDark && this.CheckInsideScope(this._Limit_Space_Flow_Pos_X) && !this.isCoolAttack;

        this.isAttackSlash = this.GetDistanceX() <= this._Distance_Attack_Slash && !this.isFlowDark && !this.isCoolAttack;

        this.isJumpAttack = this._BossCtrl.CharacterCheckContactEnviroment.CharacterCheckGround.IsGround && !this.isFlowDark && !this.isAttackSlash
          && this.GetDistanceX() <= this._Distance_OnMode_Jump_Attack && this.CheckInsideScope(this._Limit_Space_Jump_Pos_X) && !this.isCoolAttack;

        this.isShadow = !this.isFlowDark && !this.isAttackSlash && !this.isJumpAttack && this.GetDistanceX() <= this._Distance_OnMode_ShadowStep && this.CheckInsideScope(this._Limit_Space_Shadow_Pos_X) && !this.isCoolAttack;

        //  if (this._BossCtrl.CharacterCheckContactEnviroment.CharacterCheckGround.IsGround)

    }
    protected virtual float GetDistanceX()
    {
        return Mathf.Abs(PlayerCtrl.Instance.gameObject.transform.position.x - this._BossCtrl.transform.position.x);
    }

    protected virtual bool CheckInsideScope(float limit)
    {
        return Mathf.Abs(this._BossCtrl.transform.position.x) <= limit;
    }

    public virtual void ReachedLimitSpaceMustCoolAttack()
    {
        this.isCoolAttack = true;
        //After Boss move over limit  space
        Invoke(nameof(IEReachedLimitSpaceMustCoolAttack), this._Time_Recovery_Attack);
    }

    protected void IEReachedLimitSpaceMustCoolAttack()
    {
        this.isCoolAttack = false;
    }
}

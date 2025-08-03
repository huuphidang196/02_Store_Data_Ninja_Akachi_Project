using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManagerBoss : SurMonoBehaviour
{
    [SerializeField] protected BossCtrl _BossCtrl;

    //Configuration
    ///Number Data
    [SerializeField] protected float _Limit_Space_Pos_X = 24f;

    [SerializeField] protected float _Distance_OnMode_ShadowStep = 11f;
    [SerializeField] protected float _Limit_Space_Shadow_Pos_X = 11f;
    public float Distance_MoveShadow_Axis_X => 11f;

    [SerializeField] protected float _Distance_OnMode_FlowDark = 13f;
    [SerializeField] protected float _Limit_Space_Flow_Pos_X = 10f;
    public float Distance_MoveFlow_Axis_X => 10f;

    [SerializeField] protected float _Distance_Attack_Slash = 7f;

    [SerializeField] protected float _Distance_OnMode_Jump_Attack = 9f;
    [SerializeField] protected float _Limit_Space_Jump_Pos_X = 13f;
    public float Distance_MoveJump_Axis_X => this._Distance_OnMode_Jump_Attack - 1;//must == distanceOnMode - 1

    [SerializeField] protected float _Time_Recovery_Attack = 5;//seconds;

    [SerializeField] protected bool isBeginIntroduce = false;
    public bool IsBeginIntroduce => this.isBeginIntroduce;

    [SerializeField] protected bool isBeginFighter = false;
    public bool IsBeginFighter => this.isBeginFighter;

    [SerializeField] protected float _Time_Player_Recognize = 8f;//seconds;
    public float Time_Player_Recognize => this._Time_Player_Recognize;

    //Shadow

    [SerializeField] protected bool isShadow = false;
    public bool IsShadow => this.isShadow;

    [SerializeField] protected bool allowShadow = true;
    public bool AllowShadow { set => this.allowShadow = value; }

    [SerializeField] protected float _TimeDelay_Allow_Shadow = 16f;
    public float TimeDelay_Allow_Shadow => _TimeDelay_Allow_Shadow;

    //Flow Dark
    [SerializeField] protected bool isFlowDark = false;
    public bool IsFlowDark => this.isFlowDark;

    [SerializeField] protected bool allowFlowDark = true;
    public bool AllowFlowDark => this.allowFlowDark;

    [SerializeField] protected float _TimeDelay_Allow_Dark = 33f;
    public float TimeDelay_Allow_Dark => _TimeDelay_Allow_Dark;

    //Attack Slash
    [SerializeField] protected bool isAttackSlash = false;
    public bool IsAttackSlash => this.isAttackSlash;

    [SerializeField] protected bool allowSlash = true;
    public bool AllowSlash => this.allowSlash;

    [SerializeField] protected float _TimeDelay_Allow_Slash = 5f;
    public float TimeDelay_Allow_Slash => _TimeDelay_Allow_Slash;
    //JumpAttack

    [SerializeField] protected bool isJumpAttack = false;
    public bool IsJumpAttack => this.isJumpAttack;

    [SerializeField] protected bool allowJumpAttack = true;
    public bool AllowJumpAttack => this.allowJumpAttack;

    [SerializeField] protected float _TimeDelay_Allow_Jump = 8f;
    public float TimeDelay_Allow_Jump => _TimeDelay_Allow_Jump;

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

        StartCoroutine(this.SetBeginFighter());
    }

    protected IEnumerator SetBeginFighter()
    {
        yield return new WaitForSeconds(this._Time_Player_Recognize);
        this.isBeginIntroduce = true;

        yield return new WaitForSeconds(1f);
        this.isBeginFighter = true;
    }

    protected virtual void Update()
    {
        if (!this.isBeginFighter) return;

        if (PlayerCtrl.Instance.PlayerDamReceiver.ObjIsDead)
        {
            this.allowShadow = false;
            this.allowSlash = false;
            this.allowFlowDark = false;
            this.allowJumpAttack = false;

            return;
        }

        this.UpdateBoolSkill();

        //  this.SetAllowSkill();
    }

    protected virtual void UpdateBoolSkill()
    {
        if (this._BossCtrl.BossCheckContactEnviroment.BossCheckForward.TargetFollow == null)
        {
            this.isAttackSlash = false;
            this.isJumpAttack = false;
            this.isShadow = false;
            this.isFlowDark = false;
            return;
        }    

        this.isAttackSlash = this.allowSlash && this._BossCtrl.CharacterCheckContactEnviroment.CharacterCheckGround.IsGround
            && this.GetDistanceX() <= this._Distance_Attack_Slash && !this.isCoolAttack;

        this.isJumpAttack = this.allowJumpAttack && this._BossCtrl.CharacterCheckContactEnviroment.CharacterCheckGround.IsGround
          && this.GetDistanceX() <= this._Distance_OnMode_Jump_Attack && this.CheckInsideScope(this._Limit_Space_Jump_Pos_X) && !this.isCoolAttack;

        this.isShadow = this.allowShadow && this._BossCtrl.CharacterCheckContactEnviroment.CharacterCheckGround.IsGround
            && this.GetDistanceX() <= this._Distance_OnMode_ShadowStep && this.CheckInsideScope(this._Limit_Space_Shadow_Pos_X) && !this.isCoolAttack;

        this.isFlowDark = this.allowFlowDark && this._BossCtrl.CharacterCheckContactEnviroment.CharacterCheckGround.IsGround
                 && this.GetDistanceX() <= this._Distance_OnMode_FlowDark && this.CheckInsideScope(this._Limit_Space_Flow_Pos_X) && !this.isCoolAttack;
    }

    public IEnumerator SetAllowShadow(float? timeDelay)
    {
        if (!this.allowShadow) yield break;

        this.allowShadow = false;
        yield return new WaitForSeconds(timeDelay ?? this._TimeDelay_Allow_Shadow);
        this.allowShadow = true;
    }
    public IEnumerator SetAllowSlash(float? timeDelay)
    {
        if (!this.allowSlash) yield break;

        this.allowSlash = false;
        yield return new WaitForSeconds(timeDelay ?? this._TimeDelay_Allow_Slash);
        this.allowSlash = true;
    }
    public IEnumerator SetAllowDark(float? timeDelay)
    {
        if (!this.allowFlowDark) yield break;

        this.allowFlowDark = false;
        yield return new WaitForSeconds(timeDelay ?? this._TimeDelay_Allow_Dark);
        this.allowFlowDark = true;
    }

    public IEnumerator SetAllowJumpAttack(float? timeDelay)
    {
        if (!this.allowJumpAttack) yield break;

        this.allowJumpAttack = false;
        yield return new WaitForSeconds(timeDelay ?? this._TimeDelay_Allow_Jump);
        this.allowJumpAttack = true;
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


/*
protected IEnumerator SetAllowSkill(Func<bool> getValue, Action<bool> setValue)
{
    if (getValue() == this._BossCtrl.CharacterCheckContactEnviroment.CharacterCheckGround.IsGround || !getValue() && this._BossCtrl.CharacterCheckContactEnviroment.CharacterCheckGround.IsGround)
        yield break;

    setValue(this._BossCtrl.CharacterCheckContactEnviroment.CharacterCheckGround.IsGround);

    yield return new WaitForSeconds(8f);

    setValue(true);

}
*/
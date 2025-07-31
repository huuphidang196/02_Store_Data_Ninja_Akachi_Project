using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimation : CharacterAnimation
{
    [SerializeField] protected BossCtrl _BossCtrl => this._CharacterCtrl as BossCtrl;

    [Header("BossAnimation")]

    [SerializeField] protected bool isGrounded = false;
    public bool IsGrounded => this.isGrounded;

    [SerializeField] protected bool isShadow = false;
    public bool IsShadow => this.isShadow;

    [SerializeField] protected bool isFlowDarking = false;
    public bool IsFlowDark => this.isFlowDarking;

    [SerializeField] protected bool isJumpAttack = false;
    public bool IsJumpAttack => this.isJumpAttack;

    [SerializeField] protected bool isSlash = false;
    public bool IsSlash => this.isSlash;

    [SerializeField] protected bool isSlashing = false;
    public bool IsSlashing => this.isSlashing;

    [SerializeField] protected bool isDropAttacking = false;
    public bool IsDropAttacking => this.isDropAttacking;

    [SerializeField] protected bool isFlowDarkAttack = false;
    public bool IsFlowDarkAttack => this.isFlowDarkAttack;

    [SerializeField] protected SpriteRenderer _SpriteRenderer;

    protected override void LoadAllClipsAnimation()
    {
        base.LoadAllClipsAnimation();

        this.LoadSpriteRenderer();
    }

    protected virtual void LoadSpriteRenderer()
    {
        if (this._SpriteRenderer != null) return;

        this._SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected override void ProcessUpdateProcedureObjectLife()
    {
        this.UpdateBoolByInputManager();

        this.ProcessSlashing();

        this.ProcessDroppingAndDropAttack();

        this.ProcessFlowDarkAttack();

        this.UpdateAnimationControllers();

        this.SetAnimationHidenSetup();
    }

    protected virtual void ProcessSlashing()
    {
        if (!this.isSlashing && this.isSlash)
        {
            this.isSlashing = true;
            this.UpdateBoolByInputManager();
            this._Timer_Animation = 0f;
        }
        if (!this.isSlashing) return;

        if (!this.isGrounded) return;

        this.SetTimeDurationByAnimationClip("Attack_Slash");
        this._Time_Duration += Time.deltaTime;

        if (this.CheckTimer())
        {
            this.isSlashing = false;
        }
    }

    protected virtual void ProcessDroppingAndDropAttack()
    {
        if (!this.isDropAttacking && this.CheckAnimationCurrent("Dropping"))
        {
            this.isDropAttacking = true;
            this.UpdateBoolByInputManager();
            this._Timer_Animation = 0f;
        }
        if (!this.isDropAttacking) return;

        if (!this.isGrounded) return;

        this.SetTimeDurationByAnimationClip("DropAttack");
        this._Time_Duration += Time.deltaTime;

        if (this.CheckTimer())
        {
            this.SetDropAttack();
        }
    }
    protected virtual void ProcessFlowDarkAttack()
    {
        if (!this.isFlowDarkAttack && this.isFlowDarking)
        {
            this.isFlowDarkAttack = true;
            this.UpdateBoolByInputManager();
            this._Timer_Animation = 0f;
        }
        if (!this.isFlowDarkAttack) return;

        if (!this.isGrounded) return;

        this.SetTimeDurationByAnimationClip("FlowDarkAttack");
        this._Time_Duration += Time.deltaTime;

        if (this.CheckTimer())
        {
            this.SetFlowDarkAttack();
        }
    }

    protected virtual void SetDropAttack() => this.isDropAttacking = false;
    protected virtual void SetFlowDarkAttack() => this.isFlowDarkAttack = false;
    protected virtual void UpdateAnimationControllers()
    {

        this.SetBoolNoRepeat("isBeginIntroduce", this._BossCtrl.InputManagerBoss.IsBeginIntroduce);

        this.SetBoolNoRepeat("BeginFighter", this._BossCtrl.InputManagerBoss.IsBeginFighter);

        this.SetBoolNoRepeat("isDead", this.isDead);

        this.SetBoolNoRepeat("EndGame", PlayerCtrl.Instance.ObjDamageReceiver.ObjIsDead);

        this.SetBoolNoRepeat("isGrounded", this.isGrounded);

        this.SetBoolNoRepeat("isCoolAttack", (this._BossCtrl.InputManagerBoss.IsCoolAttack));

        this.SetFloatNoRepeat("isCoolAttackNum", (this._BossCtrl.InputManagerBoss.IsCoolAttack ? 1f : 0f));

        this.SetBoolNoRepeat("isDropAttacking", this.isDropAttacking);

        this.SetBoolNoRepeat("isShadow", this.isShadow);

        this.SetBoolNoRepeat("isFlowDark", this.isFlowDarking);

        this.SetBoolNoRepeat("isFlowDarkAttack", this.isFlowDarkAttack);

        this.SetBoolNoRepeat("isSlash", this.isSlashing);

        this.SetFloatNoRepeat("yVelocity", this._BossCtrl.BossEnemyMovement.Rigidbody2D.velocity.y);

        this.SetBoolNoRepeat("Run", this._Run_Ani);

        this.SetTimeDurationByAnimationClip(this._Animator.GetCurrentAnimatorClipInfo(0)[0].clip.name);
    }

    protected virtual void SetBoolNoRepeat(string variableBool, bool actives)
    {
        if (this._Animator.GetBool(variableBool) == actives) return;

        this._Animator.SetBool(variableBool, actives);
    }

    protected virtual void SetFloatNoRepeat(string variableBool, float num)
    {
        if (this._Animator.GetFloat(variableBool) == num) return;

        this._Animator.SetFloat(variableBool, num);
    }

    protected virtual void UpdateBoolByInputManager()
    {
        //this._Attack_Throw_Ani = !this.isDead && !this.isHiding && InputManager.Instance.Press_Attack_Throw;

        this.isGrounded = this._BossCtrl.BossCheckContactEnviroment.CharacterCheckGround.IsGround;

        this.isJumpAttack = this._BossCtrl.BossEnemyMovement.IsJumpAttack;

        this.isShadow = this._BossCtrl.BossEnemyMovement.IsShadowing;

        this.isFlowDarking = this._BossCtrl.BossEnemyMovement.IsFlowDarkening;

        this.isSlash = this._BossCtrl.BossEnemyMovement.IsSlash;

        this._Run_Ani = (!this.isDead && !this.isDropAttacking && !this.isFlowDarkAttack && !this.isShadow && !this.isJumpAttack && !this.isSlashing && !this.isFlowDarking
            && this.isGrounded && this._BossCtrl.InputManagerBoss.IsBeginFighter && this._BossCtrl.InputManagerBoss.IsBeginIntroduce);
    }

    protected virtual void SetAnimationHidenSetup()
    {
        if (!this.isShadow && !this.isFlowDarking && this._SpriteRenderer.enabled) return;

        if (this.isShadow || this.isFlowDarking)
        {
            this.ActiveAndInActiveSkinHidenMode(false);
            return;
        }

        this.ActiveAndInActiveSkinHidenMode(true);
    }

    protected virtual void ActiveAndInActiveSkinHidenMode(bool active)
    {
        this._Animator.enabled = active;
        this._SpriteRenderer.enabled = active;

        foreach (Transform item in this.transform)
        {
            item.gameObject.SetActive(active);
        }

    }

}

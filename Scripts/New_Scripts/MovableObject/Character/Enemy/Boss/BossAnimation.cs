using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimation : CharacterAnimation
{
    [SerializeField] protected BossCtrl _BossCtrl => this._CharacterCtrl as BossCtrl;

    [Header("BossAnimation")]

    [SerializeField] protected bool isGrounded = false;
    public bool Jump_Ani => this.isGrounded;

    [SerializeField] protected bool isShadow = false;
    public bool IsShadow => this.isShadow;

    [SerializeField] protected bool isFlowDark = false;
    public bool IsFlowDark => this.isFlowDark;

    [SerializeField] protected bool isJumpAttack = false;
    public bool IsJumpAttack => this.isJumpAttack;

    [SerializeField] protected bool isSlash = false;
    public bool IsSlash => this.isSlash;

    [SerializeField] protected bool isDropAttacking = false;
    public bool IsDropAttacking => this.isDropAttacking;

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

        //if (this.CheckAnimationCurrent("BeginFighter")) return;

        this.ProcessDroppingAndDropAttack();

        this.UpdateAnimationControllers();

     //   this.SetAnimationHidenSetup();
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

        if (this.CheckTimer())
        {
            this.SetDropAttack();
        }
    }

    protected virtual void SetDropAttack() => this.isDropAttacking = false;
    protected virtual void UpdateAnimationControllers()
    {
        this.SetBoolNoRepeat("BeginFighter", this._BossCtrl.InputManagerBoss.IsBeginFighter);

        this.SetBoolNoRepeat("isDead", this.isDead);

        this.SetBoolNoRepeat("isGrounded", this.isGrounded);

        this.SetBoolNoRepeat("isCoolAttack", (this._BossCtrl.InputManagerBoss.IsCoolAttack));

        this.SetFloatNoRepeat("isCoolAttackNum", (this._BossCtrl.InputManagerBoss.IsCoolAttack ? 1f : 0f));

        this.SetBoolNoRepeat("isDropAttacking", this.isDropAttacking);

        this.SetBoolNoRepeat("isShadow", this.isShadow);

        this.SetBoolNoRepeat("isFlowDark", this.isFlowDark);

        this.SetBoolNoRepeat("isSlash", this.isSlash);

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

        this.isShadow = this._BossCtrl.BossEnemyMovement.IsShadow && this.isGrounded && !this.isDropAttacking;

        this.isFlowDark = this._BossCtrl.BossEnemyMovement.IsFlowDark && this.isGrounded && !this.isDropAttacking;

        this.isJumpAttack = this._BossCtrl.BossEnemyMovement.IsJumpAttack && !this.isDropAttacking;

        this.isSlash = this._BossCtrl.BossEnemyMovement.IsSlash && !this.isDropAttacking;

        this._Run_Ani = (!this.isDead && !this.isDropAttacking && !this.isShadow && !this.isJumpAttack && !this.isSlash && !this.isFlowDark
            && this.isGrounded && this._BossCtrl.InputManagerBoss.IsBeginFighter);
    }

    protected virtual void SetAnimationHidenSetup()
    {
        if (!this.isShadow && !this.isFlowDark && this._SpriteRenderer.enabled) return;

        if (this.isShadow)
        {
            this.ActiveAndInActiveSkinHidenMode(this.isShadow != this._SpriteRenderer.enabled);
            return;
        }

        if (this.isFlowDark != this._SpriteRenderer.enabled) return;

        this.ActiveAndInActiveSkinHidenMode(this.isFlowDark != this._SpriteRenderer.enabled);

    }

    protected virtual void ActiveAndInActiveSkinHidenMode(bool active)
    {
        //this._Animator.enabled = active;
        this._SpriteRenderer.enabled = active;

        foreach (Transform item in this.transform)
        {
            item.gameObject.SetActive(active);
        }

    }

}

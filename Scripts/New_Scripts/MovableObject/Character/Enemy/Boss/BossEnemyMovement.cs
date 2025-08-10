using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyMovement : EnemyMovementOverall
{
    [SerializeField] protected BossCtrl _BossCtrl => this._MovableObjCtrl as BossCtrl;

    [Header("BossEnemyMovement")]

    [SerializeField] protected bool isGrounded = false;
    public bool Jump_Ani => this.isGrounded;

    [SerializeField] protected bool isShadow = false;
    public bool IsShadow => this.isShadow;

    [SerializeField] protected bool isShadowing = false;
    public bool IsShadowing => this.isShadowing;

    [SerializeField] protected bool isFlowDark = false;
    public bool IsFlowDark => this.isFlowDark;

    [SerializeField] protected bool isFlowDarkening = false;
    public bool IsFlowDarkening => this.isFlowDarkening;

    [SerializeField] protected bool isJumpAttack = false;
    public bool IsJumpAttack => this.isJumpAttack;

    [SerializeField] protected bool isSlash = false;
    public bool IsSlash => this.isSlash;

    [SerializeField] protected float _JumpingPower = 21f;
    [SerializeField] protected float _Time_MoveShadow = 1.5f;
    [SerializeField] protected float _Time_MoveFlow = 3f;

    [SerializeField] protected Transform _waitingVFX = null;
    protected override void ResetDataConfiguration()
    {
        base.ResetDataConfiguration();

        this._Move_Right = false;
        this.isFacingRight = false;
    }
    protected override void UpdateSpeedHorizontal()
    {
        if (this.GetConditionStopMove())
        {
            this._Horizontal = 0f;
            return;
        }

        if (this._BossCtrl.BossAnimation.IsDropAttacking)
        {
            this._Horizontal = this.CalculateVox();
            return;
        }

        this._Horizontal = (this._Move_Right) ? 1f * this.GetSpeedMoveHorizontal() : -1f * this.GetSpeedMoveHorizontal();
    }

    private bool GetConditionStopMove()
    {
        if (this.isSlash || (this._BossCtrl.BossAnimation.IsDropAttacking && this.isGrounded) || !this._BossCtrl.InputManagerBoss.IsBeginFighter
            || this.isShadowing || (this._BossCtrl.BossAnimation.IsFlowDarkAttack && this.isGrounded) || PlayerCtrl.Instance.ObjDamageReceiver.ObjIsDead
            || (this._BossCtrl.BossAnimation.IsSlashing && this.isGrounded)) return true;

        return false;
    }

    protected float CalculateVox()
    {
        float g = Mathf.Abs(Physics2D.gravity.y) * this._Rigidbody2D.gravityScale;

        float vox = this._BossCtrl.InputManagerBoss.Distance_MoveJump_Axis_X * g / (2f * this._JumpingPower);

        return (this._Move_Right) ? 1f * vox : -1f * vox;
    }

    protected virtual float GetSpeedMoveHorizontal() => !this._BossCtrl.InputManagerBoss.IsCoolAttack ? this._Speed_Dash_Horizontal : this._Speed_Move_Horizontal;

    protected override void UpdateBoolByInputManager()
    {
        base.UpdateBoolByInputManager();

        this.isGrounded = this._BossCtrl.BossCheckContactEnviroment.CharacterCheckGround.IsGround;

        this.isJumpAttack = this._BossCtrl.InputManagerBoss.IsJumpAttack && !this.isFlowDarkening && !isShadowing && !this._BossCtrl.BossAnimation.IsSlashing
            && this.CheckConditionOverallAllowResume();

        this.isShadow = this._BossCtrl.InputManagerBoss.IsShadow && !this._BossCtrl.BossAnimation.IsDropAttacking && !this.isJumpAttack && !this.isFlowDarkening
            && !this._BossCtrl.BossAnimation.IsSlashing && this.CheckConditionOverallAllowResume();

        this.isFlowDark = this._BossCtrl.InputManagerBoss.IsFlowDark && !this._BossCtrl.BossAnimation.IsDropAttacking && !this.isJumpAttack && !this.isShadowing
            && !this.isShadow && !this._BossCtrl.BossAnimation.IsSlashing && this.CheckConditionOverallAllowResume();

        if (this.isShadow && !this.isShadowing) StartCoroutine(this.ActionShadow());
        if (this.isFlowDark || this.isFlowDarkening) this.ActionFlowDarkening();

        this.isSlash = this._BossCtrl.InputManagerBoss.IsAttackSlash && !this._BossCtrl.BossAnimation.IsDropAttacking && !this.isShadowing
            && !this.isFlowDarkening && this.CheckConditionOverallAllowResume();

        if (this.isJumpAttack) this.ActionJump();
    }

    protected virtual bool CheckConditionOverallAllowResume()
    {
        return !PlayerCtrl.Instance.PlayerDamReceiver.ObjIsDead && !GamePlayController.Instance.EndGame;
    }
    protected virtual void ActionFlowDarkening()
    {
        if (!this.isFlowDarkening && this._BossCtrl.CharacterCheckContactEnviroment.CharacterCheckGround.IsGround)
        {
            this.isFlowDarkening = true;

            //VFX
            this._waitingVFX = VFXObjectSpawner.Instance.Spawn(VFXObjectSpawner.VFX_Flow_Dark, this._MovableObjCtrl.transform.position, Quaternion.identity);

            if (this._waitingVFX == null)
            {
                this.isFlowDarkening = false;
                return;
            }

            this._waitingVFX.localScale = Vector3.one;

            this._waitingVFX.gameObject.SetActive(true);

            FlowDarkCtrl flowCtrl = this._waitingVFX.GetComponent<FlowDarkCtrl>();
            flowCtrl.FlowDarkMovement.SetDirection(this._BossCtrl.transform);

            this._BossCtrl.BossSoundManager.PlaySoundFlowDark();
            return;
        }

        if (this._waitingVFX.gameObject.activeInHierarchy || this._waitingVFX == null) return;
        //Set pos
        this._BossCtrl.transform.position = new Vector3(this._waitingVFX.position.x, -1.35f, 0);

        //Active
        // this.BossCtrl.BossAnimation.gameObject.SetActive(true);
        this.isFlowDarkening = false;

        this._waitingVFX = null;
        //Set allow flow dark together
        StartCoroutine(this._BossCtrl.InputManagerBoss.SetAllowSlash(1.5f));
        StartCoroutine(this._BossCtrl.InputManagerBoss.SetAllowDark(null));


        this._BossCtrl.BossSoundManager.PlaySoundFlowDark();
    }

    protected IEnumerator ActionShadow()
    {
        this.isShadowing = true;
        //VFX
        Transform vfxShadow = VFXObjectSpawner.Instance.Spawn(VFXObjectSpawner.VFX_Shadow_Step, this._MovableObjCtrl.transform.position, Quaternion.identity);
        vfxShadow.localScale = Vector3.one;

        vfxShadow.gameObject.SetActive(true);

        this._BossCtrl.BossSoundManager.PlaySoundShadow();

        yield return new WaitForSeconds(this._Time_MoveShadow);
        //Set pos
        this._BossCtrl.transform.position +=
            new Vector3(this._BossCtrl.InputManagerBoss.Distance_MoveShadow_Axis_X * Math.Sign(this._BossCtrl.transform.localScale.x), 0f, 0);

        //VFX
        vfxShadow.position = this._MovableObjCtrl.transform.position;
        vfxShadow.gameObject.SetActive(true);

        yield return new WaitForSeconds(0.5f);
        //Active
        // this.BossCtrl.BossAnimation.gameObject.SetActive(true);
        this.isShadowing = false;

        this._BossCtrl.BossSoundManager.PlaySoundShadow();

        //SetAllow Shadow
        StartCoroutine(this._BossCtrl.InputManagerBoss.SetAllowShadow(null));
    }

    protected virtual void ActionJump()
    {
        // if (this.BossCtrl.ObjDamageReceiver.ObjIsDead) return;

        if (this.isShadow || this.isFlowDark || this.isShadowing || this.isFlowDarkening || this.isSlash) return;
        // Debug.Log("x0: " + this.BossCtrl.transform.position.x);
        this._Rigidbody2D.velocity = new Vector2(this.CalculateVox(), this._JumpingPower);

        StartCoroutine(this._BossCtrl.InputManagerBoss.SetAllowJumpAttack(null));
        StartCoroutine(this._BossCtrl.InputManagerBoss.SetAllowSlash(2.2f));
        StartCoroutine(this._BossCtrl.InputManagerBoss.SetAllowDark(1));

        this._BossCtrl.BossSoundManager.PlaySoundJump();

    }
    protected override void ChangeDirectionMovement()
    {
        if (this.EnemyCtrl.EnemyImpact.IsImpact)
        {
            //start cooltime
            this._BossCtrl.InputManagerBoss.ReachedLimitSpaceMustCoolAttack();
        }

        base.ChangeDirectionMovement();
    }


}

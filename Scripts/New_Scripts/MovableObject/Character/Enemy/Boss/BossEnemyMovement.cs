using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyMovement : EnemyMovementOverall
{
    public BossCtrl BossCtrl => this._MovableObjCtrl as BossCtrl;

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
        if (this.isSlash || (this.BossCtrl.BossAnimation.IsDropAttacking && this.isGrounded) || !this.BossCtrl.InputManagerBoss.IsBeginFighter
            || this.isShadowing || (this.isFlowDarkening && this.isGrounded) || PlayerCtrl.Instance.ObjDamageReceiver.ObjIsDead)
        {
            this._Horizontal = 0f;
            return;
        }

        if (this.BossCtrl.BossAnimation.IsDropAttacking)
        {
            this._Horizontal = this.CalculateVox();
            return;
        }

        this._Horizontal = (this._Move_Right) ? 1f * this.GetSpeedMoveHorizontal() : -1f * this.GetSpeedMoveHorizontal();
    }
    protected float CalculateVox()
    {
        float g = Mathf.Abs(Physics2D.gravity.y) * this._Rigidbody2D.gravityScale;

        float vox = this.BossCtrl.InputManagerBoss.Distance_MoveJump_Axis_X * g / (2f * this._JumpingPower);

        return (this._Move_Right) ? 1f * vox : -1f * vox;
    }

    protected virtual float GetSpeedMoveHorizontal() => !this.BossCtrl.InputManagerBoss.IsCoolAttack ? this._Speed_Dash_Horizontal : this._Speed_Move_Horizontal;

    protected override void UpdateBoolByInputManager()
    {
        base.UpdateBoolByInputManager();

        this.isGrounded = this.BossCtrl.BossCheckContactEnviroment.CharacterCheckGround.IsGround;

        this.isJumpAttack = this.BossCtrl.InputManagerBoss.IsJumpAttack && !this.isFlowDarkening && !isShadowing;

        this.isFlowDark = this.BossCtrl.InputManagerBoss.IsFlowDark && !this.BossCtrl.BossAnimation.IsDropAttacking && !this.isJumpAttack
            && !this.isShadowing && !this.isSlash;

        this.isSlash = this.BossCtrl.InputManagerBoss.IsAttackSlash && !this.BossCtrl.BossAnimation.IsDropAttacking && !this.isShadowing && !this.isFlowDarkening;

        this.isShadow = this.BossCtrl.InputManagerBoss.IsShadow && !this.BossCtrl.BossAnimation.IsDropAttacking && !this.isJumpAttack && !this.isSlash && !this.isFlowDarkening;

        if (this.isShadow && !this.isShadowing) StartCoroutine(this.ActionShadow());
        if (this.isFlowDark || this.isFlowDarkening) this.ActionFlowDarkening();

        if (this.isJumpAttack) this.ActionJump();

        //    if (this.isSlash) this.ActionAttackSlash();
    }

    protected virtual void ActionFlowDarkening()
    {
        if (!this.isFlowDarkening)
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
            flowCtrl.FlowDarkMovement.SetDirection(this.BossCtrl.transform);

            this.BossCtrl.BossEnemyDamReceiver.SetLayerIgnoreImpact(true);
            return;
        }

        if (this._waitingVFX.gameObject.activeInHierarchy) return;
        //Set pos
        this.BossCtrl.transform.position = new Vector3(this._waitingVFX.position.x, -1.35f, 0);

        //Active
        // this.BossCtrl.BossAnimation.gameObject.SetActive(true);
        this.isFlowDarkening = false;

        StartCoroutine(this.BossCtrl.InputManagerBoss.SetAllowSlash());

        //SetAllow Shadow
        StartCoroutine(this.BossCtrl.InputManagerBoss.SetAllowShadow());

        //Set allow flow dark together
        StartCoroutine(this.BossCtrl.InputManagerBoss.SetAllowDark());

        StartCoroutine(this.BossCtrl.InputManagerBoss.SetAllowJumpAttack());

        this.BossCtrl.BossEnemyDamReceiver.SetLayerIgnoreImpact(false);
    }


    protected IEnumerator ActionShadow()
    {
        this.isShadowing = true;
        //VFX
        Transform vfxShadow = VFXObjectSpawner.Instance.Spawn(VFXObjectSpawner.VFX_Shadow_Step, this._MovableObjCtrl.transform.position, Quaternion.identity);
        vfxShadow.localScale = Vector3.one;

        vfxShadow.gameObject.SetActive(true);

        this.BossCtrl.BossEnemyDamReceiver.SetLayerIgnoreImpact(true);

        yield return new WaitForSeconds(this._Time_MoveShadow);
        //Set pos
        this.BossCtrl.transform.position +=
            new Vector3(this.BossCtrl.InputManagerBoss.Distance_MoveShadow_Axis_X * Math.Sign(this.BossCtrl.transform.localScale.x), 0f, 0);

        //VFX
        vfxShadow.position = this._MovableObjCtrl.transform.position;
        vfxShadow.gameObject.SetActive(true);


        //Active
        // this.BossCtrl.BossAnimation.gameObject.SetActive(true);
        this.isShadowing = false;

        StartCoroutine(this.BossCtrl.InputManagerBoss.SetAllowSlash());

        //SetAllow Shadow
        StartCoroutine(this.BossCtrl.InputManagerBoss.SetAllowShadow());

        //Set allow flow dark together
        StartCoroutine(this.BossCtrl.InputManagerBoss.SetAllowDark());

        this.BossCtrl.BossEnemyDamReceiver.SetLayerIgnoreImpact(false);
    }

    protected virtual void ActionJump()
    {
        // if (this.BossCtrl.ObjDamageReceiver.ObjIsDead) return;

        if (this.isShadow || this.isFlowDark || this.isShadowing || this.isFlowDarkening) return;
        // Debug.Log("x0: " + this.BossCtrl.transform.position.x);
        this._Rigidbody2D.velocity = new Vector2(this.CalculateVox(), this._JumpingPower);

        StartCoroutine(this.BossCtrl.InputManagerBoss.SetAllowJumpAttack());

    }
    protected override void ChangeDirectionMovement()
    {
        if (this.EnemyCtrl.EnemyImpact.IsImpact)
        {
            //start cooltime
            this.BossCtrl.InputManagerBoss.ReachedLimitSpaceMustCoolAttack();
        }

        base.ChangeDirectionMovement();
    }


}

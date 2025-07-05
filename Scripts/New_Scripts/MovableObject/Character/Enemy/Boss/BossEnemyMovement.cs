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

    [SerializeField] protected bool isFlowDark = false;
    public bool IsFlowDark => this.isFlowDark;

    [SerializeField] protected bool isJumpAttack = false;
    public bool IsJumpAttack => this.isJumpAttack;

    [SerializeField] protected bool isSlash = false;
    public bool IsSlash => this.isSlash;

    [SerializeField] protected float _JumpingPower = 21f;

    protected override void ResetDataConfiguration()
    {
        base.ResetDataConfiguration();

        this._Move_Right = false;
        this.isFacingRight = false;
    }
    protected override void UpdateSpeedHorizontal()
    {
        if (this.isSlash || (this.BossCtrl.BossAnimation.IsDropAttacking && this.isGrounded) || !this.BossCtrl.InputManagerBoss.IsBeginFighter)
        {
            this._Horizontal = 0f;
            return;
        }

        if (this.BossCtrl.BossAnimation.IsDropAttacking)
        {
            this._Horizontal = (this._Move_Right) ? 1.5f * this._Speed_Dash_Horizontal : -1.5f * this._Speed_Dash_Horizontal;
            return;
        }

        this._Horizontal = (this._Move_Right) ? 1f * this.GetSpeedMove() : -1f * this.GetSpeedMove();
    }

    protected virtual float GetSpeedMove() => !this.BossCtrl.InputManagerBoss.IsCoolAttack ? this._Speed_Dash_Horizontal : this._Speed_Move_Horizontal;

    protected override void UpdateBoolByInputManager()
    {
        base.UpdateBoolByInputManager();

        this.isGrounded = this.BossCtrl.BossCheckContactEnviroment.CharacterCheckGround.IsGround;

        this.isJumpAttack = this.BossCtrl.InputManagerBoss.IsJumpAttack;

        this.isShadow = this.BossCtrl.InputManagerBoss.IsShadow && this.isGrounded;

        this.isSlash = this.BossCtrl.InputManagerBoss.IsAttackSlash && this.isGrounded;

        if (this.isShadow) this.ActionShadow();

        if (this.isJumpAttack) this.ActionJump();

        //    if (this.isSlash) this.ActionAttackSlash();
    }

    protected IEnumerator ActionShadow()
    {
        //VFX
        Transform vfxShadow = VFXObjectSpawner.Instance.Spawn(VFXObjectSpawner.VFX_Shadow_Step, this._MovableObjCtrl.transform.position, Quaternion.identity);
        vfxShadow.localScale = Vector3.one;

        vfxShadow.gameObject.SetActive(true);

        //Inactive Mode
        // this.BossCtrl.BossAnimation.gameObject.SetActive(false);

        yield return new WaitForSeconds(2f);
        // need 1s to move shadow + 1 active vfx

        //VFX
        vfxShadow.gameObject.SetActive(true);

        //Set pos
        this.BossCtrl.transform.position += new Vector3(this.BossCtrl.InputManagerBoss.Distance_MoveShadow_Axis_X, 0.2f, 0);

        //Active
        // this.BossCtrl.BossAnimation.gameObject.SetActive(true);

    }

    protected virtual void ActionJump()
    {
        // if (this.BossCtrl.ObjDamageReceiver.ObjIsDead) return;

        if (this.isShadow || this.isFlowDark) return;

        this._Rigidbody2D.velocity = new Vector2(this.BossCtrl.BossEnemyMovement.Rigidbody2D.velocity.x, this._JumpingPower);

        // this._PlayerCtrl.PlayerSoundManager.PlaySoundJump();

        this.isJumpAttack = false;
    }
    protected override void ChangeDirectionMovement()
    {
        base.ChangeDirectionMovement();

        //start cooltime
        this.BossCtrl.InputManagerBoss.ReachedLimitSpaceMustCoolAttack();
    }

}

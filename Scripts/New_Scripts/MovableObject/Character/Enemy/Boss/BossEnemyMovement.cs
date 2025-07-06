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
        if (this.isSlash || (this.BossCtrl.BossAnimation.IsDropAttacking && this.isGrounded) || !this.BossCtrl.InputManagerBoss.IsBeginFighter ||this.isShadowing)
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

        this.isJumpAttack = this.BossCtrl.InputManagerBoss.IsJumpAttack;

        this.isSlash = this.BossCtrl.InputManagerBoss.IsAttackSlash && !this.BossCtrl.BossAnimation.IsDropAttacking && !this.isShadowing;

        this.isShadow = this.BossCtrl.InputManagerBoss.IsShadow && !this.BossCtrl.BossAnimation.IsDropAttacking && !this.isJumpAttack && !this.isSlash;

        if (this.isShadow && !this.isShadowing) StartCoroutine(this.ActionShadow());

        if (this.isJumpAttack) this.ActionJump();

        //    if (this.isSlash) this.ActionAttackSlash();
    }

    protected IEnumerator ActionShadow()
    {
        this.isShadowing = true;
        //VFX
        Transform vfxShadow = VFXObjectSpawner.Instance.Spawn(VFXObjectSpawner.VFX_Shadow_Step, this._MovableObjCtrl.transform.position, Quaternion.identity);
        vfxShadow.localScale = Vector3.one;

        vfxShadow.gameObject.SetActive(true);
        //   Debug.Log("Shadow" + vfxShadow.name);
        //Inactive Mode
        // this.BossCtrl.BossAnimation.gameObject.SetActive(false);

        yield return new WaitForSeconds(1.5f);
        //Set pos
        this.BossCtrl.transform.position +=
            new Vector3(this.BossCtrl.InputManagerBoss.Distance_MoveShadow_Axis_X * Math.Sign(this.BossCtrl.transform.localScale.x), 0f, 0);

        //VFX
        vfxShadow.position = this._MovableObjCtrl.transform.position;
        vfxShadow.gameObject.SetActive(true);

        //yield return new WaitForSeconds(0.5f);
        // need 1s to move shadow + 1 active vfx

        //Active
        // this.BossCtrl.BossAnimation.gameObject.SetActive(true);
        this.isShadowing = false;

        StartCoroutine(this.BossCtrl.InputManagerBoss.SetAllowSlash());

        //SetAllow Shadow
        StartCoroutine(this.BossCtrl.InputManagerBoss.SetAllowShadow());

        //Set allow flow dark together
        StartCoroutine(this.BossCtrl.InputManagerBoss.SetAllowDark());

   
    }

    protected virtual void ActionJump()
    {
        // if (this.BossCtrl.ObjDamageReceiver.ObjIsDead) return;

        if (this.isShadow || this.isFlowDark) return;
        // Debug.Log("x0: " + this.BossCtrl.transform.position.x);
        this._Rigidbody2D.velocity = new Vector2(this.CalculateVox(), this._JumpingPower);

        // this._PlayerCtrl.PlayerSoundManager.PlaySoundJump();

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

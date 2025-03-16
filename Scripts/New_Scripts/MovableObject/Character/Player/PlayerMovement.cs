using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : CharacterObjMovement
{
    [SerializeField] protected PlayerCtrl _PlayerCtrl => this._MovableObjCtrl as PlayerCtrl;

    [Header("PlayerMovement")]

    [SerializeField] protected bool _Move_Left = false;
    public bool Move_Left => _Move_Left;

    [SerializeField] protected bool _First_Jump = false;
    public bool First_Jump => this._First_Jump;

    [SerializeField] protected bool _Double_Jump = false;
    public bool Double_Jump => this._Double_Jump;

    [SerializeField] protected bool isWallSliding = false;
    public bool IsWallSliding => isWallSliding;
    [SerializeField] protected bool isWallJumping = false;

    [SerializeField] protected float _JumpingPower = 17f;
    [SerializeField] protected float _WallSlidingSpeed = 3f;
    [SerializeField] protected float _WallJumpingDirection;
    [SerializeField] protected float _WallJumpingDuration = 0.4f;
    [SerializeField] protected Vector2 _WallJumpingPower;

    [SerializeField] protected float _Original_Gravity = 5f;

    //[SerializeField] protected bool canDash = false;
    [SerializeField] protected bool isDashing = false;
    public bool IsDashing => isDashing;

    [SerializeField] protected float _DashingPower = 35f;
    [SerializeField] protected float _DashingTime = 0.3f;

    [SerializeField] protected bool canHiden = false;
    [SerializeField] protected bool isHiding;
    public bool IsHiding => isHiding;

    [SerializeField] protected bool isRiviving;
    public bool IsRiviving => isRiviving;

    [SerializeField] protected bool isStunned = false;
    public bool IsStunned { get => isStunned; set => isStunned = value; }

    [SerializeField] protected float _Speed_Hiding_Horizontal = 1.5f;
    [SerializeField] protected float _HidenTime = 5f;

    #region OnEnable_Disable

    protected override void OnEnable()
    {
        base.OnEnable();

        InputManager.PressJumpButton_Event += this.PressJumpEvent;
        InputManager.PressDashingButton_Event += this.PressDashingEvent;
    }
    protected override void OnDisable()
    {
        base.OnDisable();
        InputManager.PressJumpButton_Event -= this.PressJumpEvent;
        InputManager.PressDashingButton_Event -= this.PressDashingEvent;
    }
    protected override void LoadRigidbody2D()
    {
        base.LoadRigidbody2D();

        this._Rigidbody2D.gravityScale = this._Original_Gravity;
    }

    protected override void ResetDataConfiguration()
    {
        base.ResetDataConfiguration();

        this._Speed_Move_Horizontal = this._PlayerCtrl.PlayerSO.Speed_Move_Horizontal;
        this._Speed_Dash_Horizontal = this._PlayerCtrl.PlayerSO.Speed_Dash_Horizontal;
        this._Speed_Hiding_Horizontal = this._PlayerCtrl.PlayerSO.Speed_Hiding_Horizontal;
        this._WallSlidingSpeed = this._PlayerCtrl.PlayerSO.WallSlidingSpeed;

        this._Original_Gravity = this._PlayerCtrl.PlayerSO.Original_GravityScale;
        //this.canDash = false;
        this._First_Jump = false;
        this.canHiden = false;
        this.isRiviving = false;
    }

    #endregion OnEnable_Disable

    protected override void Start()
    {
        base.Start();
        //Debug.Log(transform.parent.name);
        this._WallJumpingPower = new Vector2(Mathf.Tan(5f * Mathf.Deg2Rad) * this._JumpingPower, this._JumpingPower);
    }

    protected override void Update()
    {
        if (this._PlayerCtrl.PlayerDamReceiver.ObjIsDead) return;

        if (this.isStunned) return;//Was stunned

        if (this.isDashing) return;//wait couroutine

        this.UpdateBoolByInputManager();

        if (this.isRiviving)
        {
            this.Flip();
            this._Horizontal = 0;
            this._Move_Left = false;
            this._Move_Right = false;
            return;//must need update input
        }

        this.UpdateSpeedHorizontal();

        if (this.isHiding && InputManager.Instance.Press_Hidden_Mode)
        {
            this.Flip();
            return;
        }
        this.PressHiddenEvent();
        this.WallSlide();

        base.Update();
    }

    #region Event_Button
    protected virtual void PressHiddenEvent()
    {
        // if (this._PlayerCtrl.PlayerDamReceiver.ObjIsDead) return;
        if (this.isStunned) return;//Was stunned

        if (!InputManager.Instance.Press_Hidden_Mode)
        {
            StopCoroutine(this.Hiden());
            this.ResetConfigurationPlayerAfterHiden(3f);

            return;
        }
        if (!this.canHiden) return;

        StartCoroutine(this.Hiden());

    }

    public void PressDashingEvent()
    {
        if (this._PlayerCtrl.PlayerDamReceiver.ObjIsDead) return;

        if (this.isStunned) return;//Was stunned

        if (this.isDashing) return;

        StartCoroutine(this.Dash());
    }
    public void PressJumpEvent()
    {
        if (this._PlayerCtrl.PlayerDamReceiver.ObjIsDead) return;

        if (this.isDashing || this.isHiding || this.isRiviving) return;

        this.ActionJumpByInput();
    }
    #endregion Event_Button

    protected virtual void FixedUpdate()
    {
        if (this._PlayerCtrl.PlayerDamReceiver.ObjIsDead || this.isStunned || this.isRiviving)
        {
            this._Rigidbody2D.velocity = new Vector2(0, this._Rigidbody2D.velocity.y);
            return;
        }


        if (this.isDashing) return;

        if (!this.isWallJumping)
        {
            this._Rigidbody2D.velocity = new Vector2(this._Horizontal, this._Rigidbody2D.velocity.y);
        }
    }

    protected virtual void ActionJumpByInput()
    {
        this.WallJump();

        if (this._Double_Jump && !this.IsGrounded()) return;//two time

        this._Rigidbody2D.velocity = new Vector2(_Rigidbody2D.velocity.x, this._JumpingPower);

        this._Double_Jump = !this._Double_Jump && !this.IsGrounded() && this._First_Jump;

        this._First_Jump = !this._First_Jump;

        this._PlayerCtrl.PlayerSoundManager.PlaySoundJump();
    }

    protected override void UpdateBoolByInputManager()
    {
        this.isRiviving = InputManager.Instance.IsRiviving;

        this._Move_Left = InputManager.Instance.Press_Left && !this._PlayerCtrl.PlayerDamReceiver.ObjIsDead;

        this._Move_Right = InputManager.Instance.Press_Right && !this._PlayerCtrl.PlayerDamReceiver.ObjIsDead || GateEntranceAutoRun.Instance.IsEntranceAuto;

        if (this.IsGrounded()) this._Double_Jump = false;

        // this.canDash = InputManager.Instance.Press_Attack_Dashing;

        this.canHiden = InputManager.Instance.Press_Hidden_Mode;

        if (!this._First_Jump) return;
        if (this.IsGrounded() && this._Rigidbody2D.velocity.y < 0.1f || this.isWallSliding) this._First_Jump = false;

    }

    protected virtual void UpdateSpeedHorizontal()
    {
        if (!this._Move_Left && !this._Move_Right)
        {
            this._Horizontal = 0f;
            return;
        }

        float speed_Move = !this.isHiding ? this._Speed_Move_Horizontal : this._Speed_Hiding_Horizontal;

        this._Horizontal = (this._Move_Left) ? -1f * speed_Move : 1f * speed_Move;
    }

    protected virtual bool IsGrounded()
    {
        return this._PlayerCtrl.PlayerCheckContactEnviroment.PlayerCheckGround.IsGround;
    }

    protected virtual void WallSlide()
    {
        if (this.isWallJumping)
        {
            this.isWallSliding = false;
            return;
        }
        if (this.CheckForwardIsHaveRightObjectLayer() && !this.IsGrounded() && this._Horizontal != 0)
        {
            this.isWallSliding = true;
            //this._PlayerStateMachine = PlayerStateMachine.IsWallJumping;
            this._Rigidbody2D.velocity = new Vector2(_Rigidbody2D.velocity.x, -1f * this._WallSlidingSpeed);
            //  Debug.Log("Slide: " + this._Rigidbody2D.velocity.y);
            return;
        }
        this.isWallSliding = false;
    }

    protected virtual bool CheckForwardIsHaveRightObjectLayer()
    {
        return this._PlayerCtrl.PlayerCheckContactEnviroment.PlayerCheckForward.ForwardObjRight;
    }

    protected virtual void WallJump()
    {
        this.isWallJumping = true;

        if (!this.isWallSliding)
        {
            this.isWallJumping = false;
            return;
        }

        this._WallJumpingDirection = 1f * this._MovableObjCtrl.transform.localScale.x;

        this._Rigidbody2D.velocity = new Vector2(_WallJumpingDirection * _WallJumpingPower.x, _WallJumpingPower.y);

        if (transform.localScale.x != _WallJumpingDirection)
        {
            this.isFacingRight = !this.isFacingRight;
            Vector3 localScale = this._MovableObjCtrl.transform.localScale;
            localScale.x *= -1f;
            this._MovableObjCtrl.transform.localScale = localScale;
        }

        Invoke(nameof(StopWallJumping), this._WallJumpingDuration);
    }

    protected virtual void StopWallJumping()
    {
        this.isWallJumping = false;
    }

    protected override void Flip()
    {
        if (this.isWallJumping) return;

        if (this.isRiviving)
        {
            this.isFacingRight = true;
            this.ConductFlip();
            return;
        }

        base.Flip();
    }
    protected virtual IEnumerator Dash()
    {
        isDashing = true;
        this._PlayerCtrl.PlayerDamReceiver.IgnoreLayerCollisionOfPlayerObject("Player", "WeaponEnemy", true);
        this._PlayerCtrl.PlayerDamReceiver.IgnoreLayerCollisionOfPlayerObject("Player", "StopTrap", true);
        this._PlayerCtrl.PlayerSoundManager.PlaySoundDashing();
        // Should set not interact with enemy
        this._Rigidbody2D.gravityScale = 0f;
        this._Rigidbody2D.velocity = new Vector2(this._MovableObjCtrl.transform.localScale.x * this._DashingPower, 0f);

        yield return new WaitForSeconds(this._DashingTime);

        this._Rigidbody2D.gravityScale = this._Original_Gravity;
        isDashing = false;
        this._PlayerCtrl.PlayerDamReceiver.IgnoreLayerCollisionOfPlayerObject("Player", "StopTrap", false);
        this._PlayerCtrl.PlayerDamReceiver.IgnoreLayerCollisionOfPlayerObject("Player", "WeaponEnemy", false);

    }
    protected virtual IEnumerator Hiden()
    {
        this.canHiden = false;
        this.isHiding = true;

        this._Rigidbody2D.gravityScale = 7f;

        //Change layer While player is hiding in order to avoid be recognized by enemy
        this._PlayerCtrl.PlayerDamReceiver.ChangeLayerPlayerByName("PlayerHiddenMode");

        yield return new WaitForSeconds(this._PlayerCtrl.PlayerSO.Time_Delay_Hiden);
        this.ResetConfigurationPlayerAfterHiden(this._Original_Gravity);
    }

    protected virtual void ResetConfigurationPlayerAfterHiden(float originalGravity)
    {
        this._Rigidbody2D.gravityScale = originalGravity;
        this.isHiding = false;
        this._PlayerCtrl.PlayerDamReceiver.ChangeLayerPlayerByName("Player");
    }


}

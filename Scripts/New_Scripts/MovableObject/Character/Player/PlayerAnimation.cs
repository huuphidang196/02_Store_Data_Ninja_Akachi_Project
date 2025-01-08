using System;
using UnityEngine;
using TMPro;
public class PlayerAnimation : CharacterAnimation
{
    [SerializeField] protected PlayerCtrl _PlayerCtrl => this._CharacterCtrl as PlayerCtrl;

    [Header("PlayerAnimation")]
    [SerializeField] protected bool isGrounded = false;
    public bool Jump_Ani => this.isGrounded;

    [SerializeField] protected bool isSliding = false;
    public bool Wall_Sliding_Ani => this.isSliding;

    [SerializeField] protected bool _Attack_Throw_Ani = false;
    public bool Attack_Throw_Ani => this._Attack_Throw_Ani;

    [SerializeField] protected bool isDashing = false;
    public bool Attack_Dashing_Ani => this.isDashing;

    [SerializeField] protected bool isHiding = false;
    public bool Hidden_Mode_Skill_Ani => this.isHiding;

    [SerializeField] protected bool _Rivive_Again_Ani = false;
    public bool Rivive_Again_Ani => this._Rivive_Again_Ani;

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

        this.UpdateAnimationControllers();

        this.SetAnimationHidenSetup();


    }

    protected override void OnEnable()
    {
        base.OnEnable();

        InputManager.PressAttackThrowButton_Event += this.TestThrow;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        InputManager.PressAttackThrowButton_Event -= this.TestThrow;
    }
    protected virtual void UpdateAnimationControllers()
    {
        this._Animator.SetBool("isDead", this.isDead);
        this._Animator.SetBool("isRiviving", this._Rivive_Again_Ani);
        this._Animator.SetBool("isHiding", this.isHiding);
        this._Animator.SetBool("isDashing", this.isDashing);
        
        int id_Attack = !this._Attack_Throw_Ani ? 0 : 1;
        if (id_Attack == 0) this._Timer_Animation = 0f;

        this._Animator.SetFloat("Throw_ID", id_Attack);

        this._Animator.SetBool("isGrounded", this.isGrounded);
        this._Animator.SetBool("isSliding", this.isSliding);

        this._Animator.SetFloat("yVelocity", this._PlayerCtrl.PlayerMovement.Rigidbody2D.velocity.y);

        this._Animator.SetBool("Run", this._Run_Ani);

        this.SetTimeDurationByAnimationClip(this._Animator.GetCurrentAnimatorClipInfo(0)[0].clip.name);

        if (this._Attack_Throw_Ani && !this.CheckTimer()) return;
        this._Attack_Throw_Ani = false;
    }

    protected virtual void TestThrow()
    {
        this._Attack_Throw_Ani = true;
    }
    
    protected virtual void UpdateBoolByInputManager()
    {
        //this._Attack_Throw_Ani = !this.isDead && !this.isHiding && InputManager.Instance.Press_Attack_Throw;

        this.isGrounded = this._PlayerCtrl.PlayerCheckContactEnviroment.PlayerCheckGround.IsGround;

        this.isSliding = !this.isDead && !this.isHiding && this._PlayerCtrl.PlayerMovement.IsWallSliding;

        this.isDashing = !this.isDead && !this.isHiding && this._PlayerCtrl.PlayerMovement.IsDashing;

        this.isHiding = !this.isDead && this._PlayerCtrl.PlayerMovement.IsHiding;

        this._Rivive_Again_Ani = InputManager.Instance.IsRiviving;

        this._Run_Ani = (!this.isDead && this._PlayerCtrl.PlayerCheckContactEnviroment.PlayerCheckGround.IsGround
            && InputManager.Instance.Press_Left != InputManager.Instance.Press_Right && !this.isDashing && !this.isHiding) || GateEntranceAutoRun.Instance.IsEntranceAuto;
    }

    protected virtual void SetAnimationHidenSetup()
    {
        if (!this.isHiding && this._SpriteRenderer.sprite == null) return;

        if (this.isHiding && this._SpriteRenderer.sprite != null) return;

        this.ActiveAndInActiveSkinHidenMode(!this.isHiding);

    }

    protected virtual void ActiveAndInActiveSkinHidenMode(bool active)
    {
        this._Animator.enabled = active;

        foreach (Transform item in this.transform)
        {
            item.gameObject.SetActive(active);
        }

        this._SpriteRenderer.sprite = active ? null : GamePlayController.Instance.SystemConfig.ShopControllerSO.DisguiseConfigSO.
    SkinHidenMode_Using.Sprite_Rep_Skin;
    }

}














/*
[SerializeField] protected PlayerCtrl _PlayerCtrl => this._CharacterCtrl as PlayerCtrl;

[Header("PlayerAnimation")]
[SerializeField] protected bool _Jump_Ani = false;
public bool Jump_Ani => this._Jump_Ani;

[SerializeField] protected bool _Dropping = false;
public bool Dropping => this._Dropping;

[SerializeField] protected bool _Wall_Sliding_Ani = false;
public bool Wall_Sliding_Ani => this._Wall_Sliding_Ani;

[SerializeField] protected bool _Attack_Throw_Ani = false;
public bool Attack_Throw_Ani => this._Attack_Throw_Ani;

[SerializeField] protected bool _Attack_Dashing_Ani = false;
public bool Attack_Dashing_Ani => this._Attack_Dashing_Ani;

[SerializeField] protected bool _Hidden_Mode_Skill_Ani = false;
public bool Hidden_Mode_Skill_Ani => this._Hidden_Mode_Skill_Ani;

[SerializeField] protected bool _Rivive_Again_Ani = false;
public bool Rivive_Again_Ani => this._Rivive_Again_Ani;

[SerializeField] protected float _Time_Delay_Hiden = 5f;
public float Time_Delay_Hiden => _Time_Delay_Hiden;

[SerializeField] protected SpriteRenderer _SpriteRenderer;
protected override void ResetValue()
{
    base.ResetValue();

    this._Time_Duration = 0.25f;
}

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

    if (this._Rivive_Again_Ani)
    {
        this.SetAnimationPlayerIsRiviving();
        return;
    }

    if (this._Hidden_Mode_Skill_Ani)
    {
        this.SetAnimationHidenModeSkill();
        return;
    }

    if (this._Attack_Dashing_Ani)
    {
        this.SetAnimationDashing();
        return;
    }

    int id_Attack = !this._Attack_Throw_Ani ? 0 : 1;
    if (id_Attack == 0) this._Timer_Animation = 0f;

    this._Animator.SetFloat("Throw_ID", id_Attack);

    if (!this._Wall_Sliding_Ani && !this._Jump_Ani && !this._Dropping) this.SetAnimationRun();

    if (this._Jump_Ani) this.SetAnimationJump();

    if (this._Dropping) this.SetAnimationDropping();

    if (this._Wall_Sliding_Ani) this.SetAnimationSliding();

    this.ReturnIdleFromAllState();
}

protected virtual void ReturnIdleFromAllState()
{
    if (this._Jump_Ani) return;

    if (!this._Hidden_Mode_Skill_Ani && !this._Animator.enabled) this.SetAnimationHidenCompleted();

    if (this.CheckAnimationCurrent("Idle")) return;

    if (!this._Dropping) this.SetAnimationDropped();

    if (!this._Wall_Sliding_Ani) this.SetAnimationWallSlided();

}

protected virtual void UpdateBoolByInputManager()
{
    this._Attack_Throw_Ani = !this.isDead && !this._Hidden_Mode_Skill_Ani && InputManager.Instance.Press_Attack_Throw;

    this._Run_Ani = (this._PlayerCtrl.PlayerCheckContactEnviroment.PlayerCheckGround.IsGround
        && InputManager.Instance.Press_Left != InputManager.Instance.Press_Right) || GateEntranceAutoRun.Instance.IsEntranceAuto;

    this._Jump_Ani = (!this.isDead && !this._Hidden_Mode_Skill_Ani && this._PlayerCtrl.PlayerMovement.Rigidbody2D.velocity.y > 0.2f
        && !this._PlayerCtrl.PlayerCheckContactEnviroment.PlayerCheckGround.IsGround);

    this._Wall_Sliding_Ani = !this.isDead && !this._Hidden_Mode_Skill_Ani && this._PlayerCtrl.PlayerMovement.IsWallSliding;

    this._Dropping = (!this.isDead && !this._Hidden_Mode_Skill_Ani && !this._Jump_Ani && !this._PlayerCtrl.PlayerCheckContactEnviroment.PlayerCheckGround.IsGround && !this._Wall_Sliding_Ani);

    this._Attack_Dashing_Ani = !this.isDead && !this._Hidden_Mode_Skill_Ani && this._PlayerCtrl.PlayerMovement.IsDashing;

    this._Hidden_Mode_Skill_Ani = !this.isDead && this._PlayerCtrl.PlayerMovement.IsHiding;

    this._Rivive_Again_Ani = InputManager.Instance.IsRiviving;
}

protected virtual void SetAnimationRun()
{
    string nameAnimation = (this._Run_Ani) ? "Run" : "Idle";

    if (this.CheckAnimationCurrent(nameAnimation)) return;

    this._Animator.SetBool("Run", this._Run_Ani);

}

protected virtual void SetAnimationJump()
{
    string nameAnimation = "Jump";

    if (this.CheckAnimationCurrent(nameAnimation)) return;

    this._Animator.SetTrigger("Jump");
}

protected virtual void SetAnimationSliding()
{
    string nameAnimation = "Wall_Sliding";

    if (this.CheckAnimationCurrent(nameAnimation)) return;

    this._Animator.SetTrigger("Sliding");
}
protected virtual void SetAnimationDropping()
{
    string nameAnimation = "Drop";

    if (this.CheckAnimationCurrent(nameAnimation)) return;

    this._Animator.SetTrigger("Dropping");

}

protected virtual void SetAnimationDashing()
{
    string nameAnimation = "Dashing";

    if (this.CheckAnimationCurrent(nameAnimation)) return;

    this._Animator.SetTrigger("Dashing");
}

protected virtual void SetAnimationPlayerIsRiviving()
{
    string nameAnimation = "Rivival";

    this.SetTimeDurationByAnimationClip(nameAnimation);

    if (!this.CheckTimer())
    {
        if (this.CheckAnimationCurrent(nameAnimation)) return;

        this._Animator.SetTrigger("Rivival");
        return;
    }

    InputManager.Instance.PlayerRiviveAgainCompleted();
}
public override bool CheckAnimationCurrent(string nameClip)
{
    if (this._Attack_Throw_Ani)
    {
        nameClip += "_Throw";
        this.SetTimeDurationByAnimationClip(nameClip);

    }

    bool result = base.CheckAnimationCurrent(nameClip);

    return result;
}

protected virtual void SetAnimationHidenModeSkill()
{
    // string nameAnimation = "Hiden_Mode";
    this._Time_Duration = this._Time_Delay_Hiden;

    if (!this.CheckTimer())
    {
        if (!this._Animator.enabled) return;

        this.ActiveAndInActiveSkinHidenMode(false);
    }
}

#region Return_Idle
protected virtual void SetAnimationDropped()
{
    //adjust for wall sliding
    string nameAnimation = "Drop";

    this.SetAnimationReturnIdleByName(nameAnimation);
}

protected virtual void SetAnimationWallSlided()
{
    string nameAnimation = "Wall_Sliding";

    this.SetAnimationReturnIdleByName(nameAnimation);
}

protected virtual void SetAnimationHidenCompleted()
{
    if (this._SpriteRenderer.sprite == null) return;

    this.ActiveAndInActiveSkinHidenMode(true);
    this.ReturnIdle();

}

protected virtual void ActiveAndInActiveSkinHidenMode(bool active)
{
    this._Animator.enabled = active;

    foreach (Transform item in this.transform)
    {
        item.gameObject.SetActive(active);
    }

    this._SpriteRenderer.sprite = active ? null : GamePlayController.Instance.SystemConfig.ShopControllerSO.DisguiseConfigSO.
SkinHidenMode_Using.Sprite_Rep_Skin;
}

protected virtual void ReturnIdle() => this._Animator.SetTrigger("Dropped");//=> Debug.Log("Return Idle");

protected virtual void SetAnimationReturnIdleByName(string nameAnimation)
{
    if (!this.CheckAnimationCurrent(nameAnimation)) return;

    this.ReturnIdle();

}
#endregion
*/
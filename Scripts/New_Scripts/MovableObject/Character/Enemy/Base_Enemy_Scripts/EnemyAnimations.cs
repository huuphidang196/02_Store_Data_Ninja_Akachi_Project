using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimations : CharacterAnimation
{
    public EnemyCtrl EnemyCtrl => this._CharacterCtrl as EnemyCtrl;

    [Header("EnemyAnimations")]

    [SerializeField] protected bool _Attack_Slash_Ani = false;
    public bool Attack => this._Attack_Slash_Ani;

    [SerializeField] protected float _Time_Attacking = 1.5f;
    public float Time_Delay_Attack => _Time_Attacking;

    [SerializeField] protected bool isDelayAttack = false;
    public bool IsDelayAttack => this.isDelayAttack;
    protected override void ResetValue()
    {
        base.ResetValue();
        this._Time_Attacking = this.EnemyCtrl.EnemySO.Time_Delay_Attack;
    }

    protected override void ProcessUpdateProcedureObjectLife()
    {
        this.UpdateBoolByInputManager();

        if (this._Attack_Slash_Ani)
        {
            this.SetAnimationEnemySlash();
            return;
        }

        this.SetAnimationRun();

        //this.ReturnWlakState();
    }


    protected virtual void UpdateBoolByInputManager()
    {
        this._Attack_Slash_Ani = !this.isDead && this.EnemyCtrl.EnemyAttack.isSlashing;

        this._Run_Ani = (!this.isDead && !this._Attack_Slash_Ani && this.EnemyCtrl.EnemyCheckContactEnviroment.EnemyCheckForward.ForwardObjRight);

    }

    protected virtual void SetAnimationRun()
    {
        string nameAnimation = (this._Run_Ani) ? "Run" : "Walk";

        if (this.CheckAnimationCurrent(nameAnimation)) return;

        this._Animator.SetBool("Run", this._Run_Ani);
    }

    protected virtual void SetAnimationEnemySlash()
    {
        if (this.isDelayAttack) return;

        string nameAnimation = "Slash";

        if (this.CheckAnimationCurrent(nameAnimation))
        {
            if (this.CheckTimer())
            {
                this.isDelayAttack = true;
                StartCoroutine(this.DelayAttack());
            }    
                return;
        }

        this._Time_Duration = this.GetAnimationDuration(nameAnimation);
        this._Animator.SetTrigger("Slash");
        this._Timer_Animation = 0;

    }
    protected IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(0.2f);

        this.isDelayAttack = false;
    }    
    protected virtual void ReturnWlakState()
    {
        string nameAnimation = "Run";

        if (!this._Run_Ani && this.CheckAnimationCurrent(nameAnimation)) return;

        // this._Animator.SetTrigger("Dashing");
    }


}

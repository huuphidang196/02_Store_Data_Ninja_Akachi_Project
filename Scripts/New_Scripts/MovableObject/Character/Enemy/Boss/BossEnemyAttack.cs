using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyAttack : EnemyAttack
{
    protected BossCtrl _BossCtrl => this._CharacterCtrl as BossCtrl;

    [Header("BossEnemyAttack")]

    [SerializeField] protected Transform _Pos_Spawn_VFX_Attack;
    [SerializeField] protected bool canSpawn_SlashVFX = false;

    [SerializeField] protected bool is_DropAttack_VFX = false;
    [SerializeField] protected bool canSpawn_DropAttack_VFX = false;

    [SerializeField] protected bool is_FlowDarkAttack_VFX = false;
    [SerializeField] protected bool canSpawn_FlowDarkAttack_VFX = false;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadPosSpawnBullet();
    }

    protected virtual void LoadPosSpawnBullet()
    {
        if (this._Pos_Spawn_VFX_Attack != null) return;

        this._Pos_Spawn_VFX_Attack = transform.Find("Pos_Spawn_VFX_Attack");
    }
    protected override void UpdateBoolSlash()
    {
        //Slash follow Animation => attack
        this.isSlash = this._BossCtrl.BossAnimation.IsSlash;

        this.is_DropAttack_VFX = this._BossCtrl.BossAnimation.IsDropAttacking && this._BossCtrl.BossAnimation.IsGrounded;
        this.is_FlowDarkAttack_VFX = this._BossCtrl.BossAnimation.IsFlowDarkAttack && this._BossCtrl.BossAnimation.IsGrounded;
    }

    protected override void Update()
    {
        base.Update();

        this.ActionAttackSlash();
        StartCoroutine(this.ActionDropAttack());
        StartCoroutine(this.ActionFlowDarkAttack());
    }
    protected IEnumerator ActionFlowDarkAttack()
    {
        //Check Exist
        if (!this.is_FlowDarkAttack_VFX)
        {
            this.canSpawn_FlowDarkAttack_VFX = true;
            yield break;
        }

        if (!this.canSpawn_FlowDarkAttack_VFX) yield break;

        this.canSpawn_FlowDarkAttack_VFX = false;

        yield return new WaitForSeconds(0.2f);

        // Spawn VFX Attack
        Transform vfx_attack_Flow = VFXObjectSpawner.Instance.Spawn(VFXObjectSpawner.VFX_Flow_Dark_Attack, this._Pos_Spawn_VFX_Attack.position, Quaternion.identity);

        vfx_attack_Flow.localScale = this._BossCtrl.transform.localScale;
        vfx_attack_Flow.name = VFXObjectSpawner.VFX_Flow_Dark_Attack;
        vfx_attack_Flow.gameObject.SetActive(true);
    }

    protected IEnumerator ActionDropAttack()
    {
        //Check Exist
        if (!this.is_DropAttack_VFX)
        {
            this.canSpawn_DropAttack_VFX = true;
            yield break;
        }

        if (!this.canSpawn_DropAttack_VFX) yield break;

        this.canSpawn_DropAttack_VFX = false;

        yield return new WaitForSeconds(0.2f);

        // Spawn VFX Attack
        Transform vfx_attack_Drop = VFXObjectSpawner.Instance.Spawn(VFXObjectSpawner.VFX_Drop_Attack, this._Pos_Spawn_VFX_Attack.position, Quaternion.identity);

        vfx_attack_Drop.localScale = Vector3.one;
        vfx_attack_Drop.name = VFXObjectSpawner.VFX_Drop_Attack;
        vfx_attack_Drop.gameObject.SetActive(true);
    }

    protected virtual void ActionAttackSlash()
    {
        //Check Exist
        if (!this.isSlash)
        {
            this.canSpawn_SlashVFX = true;
            return;
        }

        if (!this.canSpawn_SlashVFX) return;

        this.canSpawn_SlashVFX = false;

        // Spawn VFX Attack
        Transform vfx_attack_Slash = WeaponCharacterSpawner.Instance.Spawn(WeaponCharacterSpawner.VFX_Slash_Attack, this._Pos_Spawn_VFX_Attack.position, Quaternion.identity);

        //Set Direction fly
        WeaponCharacterCtrl WeaponCharacterCtrl = vfx_attack_Slash.GetComponent<WeaponCharacterCtrl>();
        WeaponCharacterCtrl.WeaponCharacterMovement.SetDirectionFly(this._CharacterCtrl.transform);

        vfx_attack_Slash.localScale = Vector3.one;
        vfx_attack_Slash.name = WeaponCharacterSpawner.VFX_Slash_Attack;
        vfx_attack_Slash.gameObject.SetActive(true);

        StartCoroutine(this._BossCtrl.InputManagerBoss.SetAllowSlash(null));
        StartCoroutine(this._BossCtrl.InputManagerBoss.SetAllowDark(1));
        StartCoroutine(this._BossCtrl.InputManagerBoss.SetAllowShadow(1));
        StartCoroutine(this._BossCtrl.InputManagerBoss.SetAllowJumpAttack(1));
    }

}

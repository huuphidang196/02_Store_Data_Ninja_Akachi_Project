using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WeaponCharacterImpact : ObjImpactTrigger
{
    public WeaponCharacterCtrl WeaponCharacterCtrl => this._ObjectCtrl as WeaponCharacterCtrl;

    [Header("WeaponCharacterImpact")]
    [SerializeField] protected bool isImpacted_Igniting_Fire = false;
    public bool IsImpacted_Igniting_Fire => this.isImpacted_Igniting_Fire;

    [SerializeField] protected bool isImpacted_Emit_Blood = false;
    public bool IsImpacted_Emit_Blood => this.isImpacted_Emit_Blood;

    [SerializeField] protected bool isImpacted_Emit_Ground = false;
    public bool IsImpacted_Emit_Ground => this.isImpacted_Emit_Ground;

    [SerializeField] protected bool isImpacted_Emit_WoodBox = false;
    public bool IsImpacted_Emit_WoodBox => this.isImpacted_Emit_WoodBox;

    protected override void Reborn()
    {
        base.Reborn();

        this.isImpacted_Emit_Blood = false;
        this.isImpacted_Igniting_Fire = false;
        this.isImpacted_Emit_Ground = false;
        this.isImpacted_Emit_WoodBox = false;
    }

    protected override void LoadRigidbody2D()
    {
        base.LoadRigidbody2D();

        this._Rigidbody2D.bodyType = RigidbodyType2D.Kinematic;

        this._Rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionY;
    }

    protected override Transform GetParentOfCollider(Collider2D collider2D)
    {
        if (collider2D.gameObject.layer != LayerMask.NameToLayer("Ground"))
            return base.GetParentOfCollider(collider2D);

        return collider2D.transform;
    }

    protected override bool CheckConditionOverallAllowImpact()
    {
        if (this.CheckParentObjectImpactWithAnyLayer("Ground")) return true;

        if (this.CheckParentObjectImpactWithAnyLayer(this.GetArrayNameTargetAttack())) return true;

        if (this.CheckParentObjectImpactWithAnyLayer("Item")) return true;

       // if (this.CheckParentObjectImpactWithAnyLayer("LethalObstacles")) return true;

        if (this.CheckParentObjectImpactWithAnyLayer("StaticObstacle")) return true;
        return false;
    }

    protected override void ProcessImpactTrigger()
    {
        // Debug.Log("name: " + this._parentObj.name + ", layer: " + LayerMask.LayerToName(this._parentObj.gameObject.layer));
        //Call OnDead in DamReceiver of Shuriken
        this.WeaponCharacterCtrl.WeaponCharacterDamReceiver.OnDeadByInfiniteDamage();

        if (this.CheckParentObjectImpactWithAnyLayer("Ground"))
        {
            this.isImpacted_Emit_Ground = true;
            this.WeaponCharacterCtrl.ObjDamageSender.Send(this._parentObj);
            this.WeaponCharacterCtrl.WeaponCharacterVFXManager.SpawnVFXBGroundEmit();
            return;
        }

        if (!this.CheckParentObjectImpactWithAnyLayer(new string[] { this.GetNameTargetAttack(), "Item" }))
        {
            this.isImpacted_Igniting_Fire = true;
            this.WeaponCharacterCtrl.WeaponCharacterVFXManager.SpawnVFXIgniteFire();
            return;
        }

        this.WeaponCharacterCtrl.ObjDamageSender.Send(this._parentObj);

        if (this.CheckParentObjectImpactWithAnyLayer("Item"))
        {
            this.isImpacted_Emit_WoodBox = true;
            this.WeaponCharacterCtrl.WeaponCharacterVFXManager.SpawnVFXWoodBoxEmit();
            return;
        }

        this.isImpacted_Emit_Blood = true;
        this.WeaponCharacterCtrl.WeaponCharacterVFXManager.SpawnVFXBloodEnemyEmit();

    }
    protected virtual string GetNameTargetAttack() => "";
    protected virtual string[] GetArrayNameTargetAttack() => new string[] { "" };
}

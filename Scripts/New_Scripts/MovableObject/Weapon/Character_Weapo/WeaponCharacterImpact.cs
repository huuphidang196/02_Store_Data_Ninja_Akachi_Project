using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;

[Serializable]
public enum TypeImpact
{
    NoImapct = 0,

    Igniting_Fire = 1,
    Emit_Blood = 2,
    Emit_Ground = 3,
    Emit_WoodBox = 4,
}

public class WeaponCharacterImpact : ObjImpactBoxColliderTrigger
{
    public WeaponCharacterCtrl WeaponCharacterCtrl => this._ObjectCtrl as WeaponCharacterCtrl;

    [Header("WeaponCharacterImpact")]

    [SerializeField] protected TypeImpact _TypeImpact = TypeImpact.NoImapct;
    public TypeImpact TypeImpact => this._TypeImpact;
    protected override void ResetValue()
    {
        base.ResetValue();

        this._TypeImpact = TypeImpact.NoImapct;
    }

    protected override void LoadRigidbody2D()
    {
        base.LoadRigidbody2D();

        this._Rigidbody2D.bodyType = RigidbodyType2D.Kinematic;

        this._Rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionY;
    }

    protected override Transform GetParent(GameObject col)
    {
        if (col.gameObject.layer != LayerMask.NameToLayer("Ground"))
            return base.GetParent(col);

        return col.transform;
    }
   

    protected override bool CheckObjectImapactAllowedImpact()
    {
        if (this.CheckParentObjectImpactWithAnyLayer("Ground")) return true;

        if (this.CheckParentObjectImpactWithAnyLayer(this.GetArrayNameAllowImpact())) return true;

        if (this.CheckParentObjectImpactWithAnyLayer("Item")) return true;

        if (this.CheckParentObjectImpactWithAnyLayer("LethalObstacles")) return true;

        if (this.CheckParentObjectImpactWithAnyLayer("StaticObstacle")) return true;
        return false;
    }

    protected override void ProcessAfterObjectImpacted()
    {
        // Debug.Log("name: " + this._parentObj.name + ", layer: " + LayerMask.LayerToName(this._parentObj.gameObject.layer));
        //Call OnDead in DamReceiver of Shuriken
        this.WeaponCharacterCtrl.WeaponCharacterDamReceiver.OnDeadByInfiniteDamage();

        if (this.CheckParentObjectImpactWithAnyLayer("Ground"))
        {
            //this.isImpacted_Emit_Ground = true;
            this.WeaponCharacterCtrl.ObjDamageSender.Send(this._parentObj);
            this._TypeImpact = TypeImpact.Emit_Ground;

            this.WeaponCharacterCtrl.WeaponCharacterVFXManager.SpawnVFXBGroundEmit();
            return;
        }

        if (!this.CheckParentObjectImpactWithAnyLayer(this.GetArrayNameTargetAttack()) && !this.CheckParentObjectImpactWithAnyLayer("Item"))
        {
            //this.isImpacted_Igniting_Fire = true;
            this._TypeImpact = TypeImpact.Igniting_Fire;

            this.WeaponCharacterCtrl.WeaponCharacterVFXManager.SpawnVFXIgniteFire();
            return;
        }

        this.WeaponCharacterCtrl.ObjDamageSender.Send(this._parentObj);
        //  Debug.Log(this._parentObj.name + ", was impacted");
        if (this.CheckParentObjectImpactWithAnyLayer("Item"))
        {
            //this.isImpacted_Emit_WoodBox = true;
            this._TypeImpact = TypeImpact.Emit_WoodBox;

            this.WeaponCharacterCtrl.WeaponCharacterVFXManager.SpawnVFXWoodBoxEmit();
            return;
        }

        this._TypeImpact = TypeImpact.Emit_Blood;
        // this.isImpacted_Emit_Blood = true;

        this.WeaponCharacterCtrl.WeaponCharacterVFXManager.SpawnVFXBloodEnemyEmit();

    }
    protected virtual string[] GetArrayNameTargetAttack() => new string[] { "" };
    protected virtual string[] GetArrayNameAllowImpact() => new string[] { "" };

    public virtual void SetStatusWeaponImpact() => this._TypeImpact = TypeImpact.NoImapct;
}

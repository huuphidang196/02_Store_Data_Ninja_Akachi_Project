using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class WeaponCharacterCtrl : MovableObjCtrl
{
    public WeaponSO WeaponSO => this._MObjScriptableObject as WeaponSO;

    public WeaponCharacterDamReceiver WeaponCharacterDamReceiver => this._ObjDamageReceiver as WeaponCharacterDamReceiver;
    public WeaponCharacterImpact WeaponCharacterImpact => this._ObjImpact_Overall as WeaponCharacterImpact;

    public WeaponCharacterMovement WeaponCharacterMovement => this._MovableObj_Movement as WeaponCharacterMovement;

    [Header("WeaponCharacterCtrl")]

    [SerializeField] protected Transform _Model;
    public Transform Model => this._Model;

    [SerializeField] protected WeaponCharacterVFXManager _WeaponCharacterVFXManager;
    public WeaponCharacterVFXManager WeaponCharacterVFXManager => this._WeaponCharacterVFXManager;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadModel();
        this.LoadWeaponCharacterVFXManager();
    }

    protected virtual void LoadWeaponCharacterVFXManager()
    {
        if (this._WeaponCharacterVFXManager != null) return;

        this._WeaponCharacterVFXManager = GetComponentInChildren<WeaponCharacterVFXManager>();
    }

    protected virtual void LoadModel()
    {
        if (this._Model != null) return;

        this._Model = transform.Find("Model");
    }

    protected override string GetNameFolderTypeObject()
    {
        return "Weapon";
    }
}

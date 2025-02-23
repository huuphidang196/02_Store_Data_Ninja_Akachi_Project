using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicMovementCtrl : MovableObjCtrl
{
    public MovableObjKinematicMovement MovableObjKinematicMovement => this._MovableObj_Movement as MovableObjKinematicMovement;
    public DynamicProspectObjMovementSO DynamicProspectObjMovementSO => this._MObjScriptableObject as DynamicProspectObjMovementSO;

    [Header("DynamicMovementCtrl")]

    [SerializeField] protected DynamicProspectContainerPlayer _DynamicProspectContainerPlayer;

    public DynamicProspectContainerPlayer DynamicProspectContainerPlayer => this._DynamicProspectContainerPlayer;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadDynamicProspectContainerPlayer();
    }

    protected virtual void LoadDynamicProspectContainerPlayer()
    {
        if (this._DynamicProspectContainerPlayer != null) return;

        this._DynamicProspectContainerPlayer = GetComponentInChildren<DynamicProspectContainerPlayer>();
    }

    protected override string GetNameFolderTypeObject()
    {
        return "Prospect";
    }
}

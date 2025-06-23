using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCheckForward : CharacterCheckForward
{
    public EnemyCheckContactEnviroment EnemyCheckContactEnviroment => this._CharacterCheckContactEnviroment as EnemyCheckContactEnviroment;
    [Header("EnemyCheckForward")]
    [SerializeField] protected Transform _TargetFollow;
    public Transform TargetFollow => this._TargetFollow;


    [SerializeField] protected bool isChangedDirForward = false;
    public bool IsChangedDirForward => this.isChangedDirForward;

    [SerializeField] protected bool isScanning = false;
    public bool IsScanning => this.isScanning;


    protected override void LoadLayerMaskForward()
    {
        if (this._ObjForwardLayer.Length > 0) return;

        this._ObjForwardLayer = new string[4];
        this._ObjForwardLayer[0] = "Player";
        this._ObjForwardLayer[1] = "Ground";
        this._ObjForwardLayer[2] = "BoxChangeDir";
        this._ObjForwardLayer[3] = "PlayerHiddenMode";
    }

    protected override void ProcessFixedUpdateEvent()
    {
        base.ProcessFixedUpdateEvent();

        if (!this.isOtherConditionAllow || this.EnemyCheckContactEnviroment.EnemyCtrl.EnemyImpact.IsImpact)
        {
            this.SetBoolAfterImpactOrNotAllow();
            
            return;
        }

        this.UpdateTargetPlayerAppear();
    }

    protected virtual void SetBoolAfterImpactOrNotAllow()
    {
        this.isChangedDirForward = false;
        this.isScanning = false;
    }

    protected override bool CheckAllOtherConditionsToContinue()
    {
        return Mathf.Abs(this.GetVectorToPlayer().x) < this._Length_Raycast && this.GetVectorToPlayer().y > -0.5f;
    }

    protected virtual Vector2 GetVectorToPlayer() => PlayerCtrl.Instance.transform.position + Vector3.up - this.EnemyCheckContactEnviroment.EnemyCtrl.transform.position;

    protected virtual void UpdateTargetPlayerAppear()
    {
        if (!this._ForwardObjRight || this.isScanning)
        {
            this.ScanTargetOnFOV();
            return;
        }
        // Transform col = this.CheckForwardIsHaveRightObjectLayer().collider.transform;

        this._TargetFollow = PlayerCtrl.Instance.transform;
        this.isChangedDirForward = false;
        this.isScanning = false;
    }

    protected virtual void SetChangeDirection()
    {
        float localX = this.EnemyCheckContactEnviroment.EnemyCtrl.transform.localScale.x;
        this.isChangedDirForward = (localX * this._Direction_Raycast2D.x < 0 && Mathf.Abs(this._Direction_Raycast2D.x) > 0.05f) ? true : false;
    }

    public virtual void ScanTargetAfterWasHurt()
    {
        if (this._ForwardObjRight) return;

        this._TargetFollow = PlayerCtrl.Instance.transform;
    }
    protected virtual void ScanTargetOnFOV()
    {
        if (this._TargetFollow == null) return;

        this.isScanning = true;

        this.GenerateAndDrawAllRaycastHits();

        //exclude enemy Shooter
        if (this.CheckConditionAllowFlip())
        {
            this.SetChangeDirection();

            return;
        }

        this._TargetFollow = null;
        this.isScanning = false;
    }

    protected virtual bool CheckConditionAllowFlip()
    {
        if (this._TargetFollow.gameObject.layer == LayerMask.NameToLayer("PlayerDead")) return false;

        for (int i = 1; i < this._ObjForwardLayer.Length; i++)
        {
            if (this.CheckForwardIsHaveRightObjectLayerCustom(this._ObjForwardLayer[i])) return false;
        }

        return true;
    }

    protected override Vector2 GetDirectionRaycast()
    {
        if (this.isScanning) return this.GetVectorToPlayer();

        return base.GetDirectionRaycast();
    }

    protected override bool CheckIsFacingTargetLayer()
    {
        if (!base.CheckIsFacingTargetLayer()) return false;

        if (!this.CheckForwardIsHaveRightObjectLayerCustom(this._ObjForwardLayer[1])) return true;

        return this.CheckDistanceForwardWithLayer(1);
    }

    protected virtual bool CheckDistanceForwardWithLayer(int order)
    {
        if (!this.CheckForwardIsHaveRightObjectLayerCustom(this._ObjForwardLayer[order])) return true;

        float length_Player = this.GetDistanceForwardIsHaveRightObjectLayerCustom(this._ObjForwardLayer[0]);
        float length_LayerCheck = this.GetDistanceForwardIsHaveRightObjectLayerCustom(this._ObjForwardLayer[order]);

        return length_LayerCheck >= length_Player;
    }

    public virtual float GetDistanceFacingPlayer()
    {
        if (!this._ForwardObjRight) return 0;

        return this.GetDistanceForwardIsHaveRightObjectLayerCustom(this._ObjForwardLayer[0]);
    }

    protected virtual float GetDistanceForwardIsHaveRightObjectLayerCustom(string layerCheck)
    {
        RaycastHit2D hit = this.GetHitForwardIsHaveRightObjectLayerCustom(layerCheck);

        if (hit.collider == null) return 0;

        return hit.distance;
    }
}








/*
public EnemyCheckContactEnviroment EnemyCheckContactEnviroment => this._CharacterCheckContactEnviroment as EnemyCheckContactEnviroment;
[Header("EnemyCheckForward")]
[SerializeField] protected Transform _TargetFollow;
public Transform TargetFollow => this._TargetFollow;

[SerializeField] protected float _Distance_Change_Dir_Enemy = 0.5f;
[SerializeField] protected float _DetectionRange = 3f;
[SerializeField] protected float _FieldOfViewAngle = 180f;

[SerializeField] protected bool isChangedDirForward = false;
public bool IsChangedDirForward => this.isChangedDirForward;

protected override void LoadLayerMaskForward()
{
    if (this._ObjForwardLayer.Length > 0) return;
    //this._ObjForwardLayer = new LayerMask[2];
    //this._ObjForwardLayer[0] = 1 << LayerMask.NameToLayer("Player");
    //this._ObjForwardLayer[1] = 1 << LayerMask.NameToLayer("Enemy");
    this._ObjForwardLayer = new string[2];
    this._ObjForwardLayer[0] = "Player";
    this._ObjForwardLayer[1] = "Ground";
}

protected override void ResetValue()
{
    base.ResetValue();

    this._Distance_Change_Dir_Enemy = this.EnemyCheckContactEnviroment.EnemyCtrl.EnemySO.Distance_Change_Dir_Enemy;
    this._DetectionRange = this.EnemyCheckContactEnviroment.EnemyCtrl.EnemySO.DetectionRange;
    this._FieldOfViewAngle = this.EnemyCheckContactEnviroment.EnemyCtrl.EnemySO.FieldOfViewAngle;
}
protected override void FixedUpdate()
{
    base.FixedUpdate();
    this.UpdateTargetPlayerAppear();
}

protected virtual void UpdateTargetPlayerAppear()
{
    if (!this._ForwardObjRight)
    {
        this.ScanTargetOnFOV();
        return;
    }
    // Transform col = this.CheckForwardIsHaveRightObjectLayer().collider.transform;

    this._TargetFollow = PlayerCtrl.Instance.transform;
    this.isChangedDirForward = false;
    // Debug.Log("Don't change");
}

protected virtual void SetChangeDirection(Vector2 directionToPlayer)
{
    float localX = this.EnemyCheckContactEnviroment.EnemyCtrl.transform.localScale.x;
    this.isChangedDirForward = (localX * directionToPlayer.x < 0 && directionToPlayer.x > 0.1f) ? true : false;
}

protected virtual void ScanTargetOnFOV()
{
    if (this._TargetFollow == null)
    {
        this.isChangedDirForward = false;
        return;
    }
    Vector2 directionToPlayer = this._TargetFollow.position - this.EnemyCheckContactEnviroment.EnemyCtrl.transform.position;
    float angle = Vector2.Angle(this.EnemyCheckContactEnviroment.EnemyCtrl.transform.right, directionToPlayer);

    if (directionToPlayer.magnitude < this._DetectionRange && angle < this._FieldOfViewAngle)
    {
        // Player nằm trong FOV, bắt đầu follow
        this.SetChangeDirection(directionToPlayer);
        //Debug.Log("Detect, magnitude" + directionToPlayer.magnitude + ", angle : " + angle);
        return;
    }
    //Debug.Log("NonDetect, magnitude" + directionToPlayer.magnitude + ", angle : " + angle);

    //Check Forward cannot find and it isn't on sacn range so target = null
    this._TargetFollow = null;
}

protected override bool CheckIsFacingTargetLayer()
{
    if (!base.CheckIsFacingTargetLayer()) return false;

    if (!this.CheckForwardIsHaveRightObjectLayerCustom(this._ObjForwardLayer[1])) return true;

    float length_Player = this.GetDistanceForwardIsHaveRightObjectLayerCustom(this._ObjForwardLayer[0]);
    float length_Ground = this.GetDistanceForwardIsHaveRightObjectLayerCustom(this._ObjForwardLayer[1]);

    return length_Ground >= length_Player;
}

public virtual float GetDistanceFacingPlayer()
{
    if (!this._ForwardObjRight) return 0;

    return this.GetDistanceForwardIsHaveRightObjectLayerCustom(this._ObjForwardLayer[0]);
}

protected virtual float GetDistanceForwardIsHaveRightObjectLayerCustom(string layerCheck)
{
    RaycastHit2D hit = this.GetHitForwardIsHaveRightObjectLayerCustom(layerCheck);

    if (hit.collider == null) return 0;

    return hit.distance;
}
*/
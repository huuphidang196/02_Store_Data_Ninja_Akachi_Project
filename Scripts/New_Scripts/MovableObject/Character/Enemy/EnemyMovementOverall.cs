using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyMovementOverall : CharacterObjMovement
{
    public EnemyCtrl EnemyCtrl => this._MovableObjCtrl as EnemyCtrl;

    [Header("EnemyMovement")]

    [SerializeField] protected bool isChangeDir = false;
    public bool IsChangeDir => this.isChangeDir;

    protected override void Reborn()
    {
        base.Reborn();

        this._Rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
    }

    protected override void ResetDataConfiguration()
    {
        this._Move_Right = true;

        this._Horizontal = this.EnemyCtrl.EnemySO.Speed_Move_Horizontal;
        this._Speed_Dash_Horizontal = this.EnemyCtrl.EnemySO.Speed_Dash_Horizontal;
        this._Speed_Move_Horizontal = this._Horizontal;
    }
    protected override void LoadRigidbody2D()
    {
        base.LoadRigidbody2D();

        this._Rigidbody2D.gravityScale = 3f;
        this._Rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    protected override void UpdateBoolByInputManager()
    {
        //Change Direction by check forward player and enemy Impact turn collider2D
        this.isChangeDir = (this.EnemyCtrl.EnemyCheckContactEnviroment.EnemyCheckForward.IsChangedDirForward ||
            this.EnemyCtrl.EnemyImpact.IsImpact);

        if (this.isChangeDir)
            this.ChangeDirectionMovement();

    }

    protected override void Update()
    {
        //  if (GameController.Instance.PauseGame) return;

        if (this.EnemyCtrl.EnemyDamReceiver.ObjIsDead) return;

        this.UpdateBoolByInputManager();
        this.UpdateSpeedHorizontal();
        base.Update();
    }

    protected abstract void UpdateSpeedHorizontal();


    protected virtual void FixedUpdate()
    {
        if (this.EnemyCtrl.EnemyDamReceiver.ObjIsDead) return;

        this._Rigidbody2D.velocity = new Vector2(this._Horizontal, this._Rigidbody2D.velocity.y);
        //Debug.Log("Speed : " + this._Rigidbody2D.velocity);
    }

    protected virtual void ChangeDirectionMovement()
    {
        this._Move_Right = !this._Move_Right;
        this.EnemyCtrl.EnemyImpact.SetChangeBoolImpact(false);
    }
}

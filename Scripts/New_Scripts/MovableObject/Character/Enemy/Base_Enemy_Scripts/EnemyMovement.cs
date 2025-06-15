using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : EnemyMovementOverall
{
    [Header("EnemyMovement")]
    [SerializeField] protected bool isFacingPlayer;
   
    protected override void ResetDataConfiguration()
    {
        base.ResetDataConfiguration();

        this.isFacingPlayer = false;
    }

    protected override void UpdateBoolByInputManager()
    {
        base.UpdateBoolByInputManager();

        //Must facing after set change Direct
        this.isFacingPlayer = this.EnemyCtrl.EnemyCheckContactEnviroment.EnemyCheckForward.ForwardObjRight;

    }

    protected override void UpdateSpeedHorizontal()
    {
        if (this.EnemyCtrl.EnemyAttack.isSlashing || this.EnemyCtrl.EnemyAnimations.CheckAnimationCurrent("Slash"))
        {
            this._Horizontal = 0;
            return;
        }

        float speed_Move = this.isFacingPlayer ? this._Speed_Dash_Horizontal : this._Speed_Move_Horizontal;

        this._Horizontal = (this._Move_Right) ? 1f * speed_Move : -1f * speed_Move;
    }
}

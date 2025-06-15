using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyMovement : EnemyMovementOverall
{
    [Header("BossEnemyMovement")]

    [SerializeField] protected bool isCoolAttack = false;
    public bool IsCoolAttack => this.isCoolAttack;

    protected override void UpdateSpeedHorizontal()
    {
        float speed_Move = !this.isCoolAttack ? this._Speed_Dash_Horizontal : this._Speed_Move_Horizontal;

        this._Horizontal = (this._Move_Right) ? 1f * speed_Move : -1f * speed_Move;
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooterHiddenMovement : EnemyMovement
{
    protected override void ResetDataConfiguration()
    {
        this._Move_Right = false;
        this.isFacingRight = false;

        this._Horizontal = 0;
        this._Speed_Dash_Horizontal = 0;
        this._Speed_Move_Horizontal = 0;
        this.isFacingPlayer = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMoveRightPlayer : BaseButtonControlMovementPlayer
{
    protected override void OnButtonDown()
    {
        base.OnButtonDown();

        InputManager.Instance.PointerRightDown();
    }

    protected override void OnButtonUp()
    {
        base.OnButtonUp();
        InputManager.Instance.PointerRightUp();
    }
}

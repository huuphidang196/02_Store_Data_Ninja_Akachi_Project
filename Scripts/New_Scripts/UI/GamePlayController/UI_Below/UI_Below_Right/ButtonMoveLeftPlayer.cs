using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMoveLeftPlayer : BaseButtonControlMovementPlayer
{
    protected override void OnButtonDown()
    {
        base.OnButtonDown();

        InputManager.Instance.PointerLeftDown();
    }

    protected override void OnButtonUp()
    {
        base.OnButtonUp();
        InputManager.Instance.PointerLeftUp();
    }
}

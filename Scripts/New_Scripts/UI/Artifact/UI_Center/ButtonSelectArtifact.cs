using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSelectArtifact : BaseButton
{
    protected override void OnClick()
    {
        base.OnClick();

        UICenterArtifactManager.Instance.ChangeSelectItemArtifact(transform.parent.GetSiblingIndex());
    }
}

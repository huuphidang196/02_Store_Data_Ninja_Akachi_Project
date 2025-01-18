using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonUnlockArtifact : BaseButton
{
    protected override void OnClick()
    {
        base.OnClick();

        ArtifactItem artifactItem = ArtifactSceneManager.Instance.SystemConfig.ArtifactConfigSO.List_ArtifactItems[UICenterArtifactManager.Instance.Order_Artifact_Selected];
        ArtifactSceneManager.Instance.UnlockArtifactByPurchasing(artifactItem);
       // Debug.Log("type: " + artifactItem.TypeNameArtifact);
    }
}

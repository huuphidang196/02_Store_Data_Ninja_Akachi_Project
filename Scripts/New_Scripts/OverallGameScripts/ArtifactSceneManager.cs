using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactSceneManager : SystemController
{
    private static ArtifactSceneManager m_instance;
    public static ArtifactSceneManager Instance => m_instance;

    protected override void Awake()
    {
        base.Awake();

        if (m_instance != null) Debug.LogError("Allow only ArtifactSceneManager has been exist");

        m_instance = this;
    }

    public virtual void UnlockArtifactByPurchasing(ArtifactItem artifactItem)
    {
      //  Debug.Log("type: " + artifactItem.TypeNameArtifact);
        if (artifactItem == null) return;

        if (artifactItem.TypeNameArtifact == TypeNameArtifact.NoType) return;

        bool purchasing_Success = this.TestPurchasing();

        if (!purchasing_Success) return;

        artifactItem.Unlock = true;
  
        //Update Artifact display immidiately
        UICenterArtifactManager.Instance.ChangeSelectItemArtifact(UICenterArtifactManager.Instance.Order_Artifact_Selected);
        //Save immidiately
        ///
    }

    private bool TestPurchasing() => true;
    
}

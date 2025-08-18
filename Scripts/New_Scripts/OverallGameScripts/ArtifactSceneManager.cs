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

        artifactItem.Unlock = true;

        //Update Artifact display immidiately
        UICenterArtifactManager.Instance.ChangeSelectItemArtifact(UICenterArtifactManager.Instance.Order_Artifact_Selected);

        //Process Conduct artifact
        this.ProcessConductArtifact(artifactItem);
        //Save immidiately
        ///

    }

    protected virtual void ProcessConductArtifact(ArtifactItem artifactItem)
    {
        if (artifactItem.TypeNameArtifact == TypeNameArtifact.Golden_Shuriken)
        {

            this._SystemConfig.PlayerSO.ShurikenSO.Damage_Send *= 2f;
            return;
        }

        if (artifactItem.TypeNameArtifact == TypeNameArtifact.Sacred_Tsuka)
        {
            this._SystemConfig.GamePlayConfigUIOverall.Time_Delay_Active_Button_Attack_Dashing *= 0.8f;
            return;
        }
        if (artifactItem.TypeNameArtifact == TypeNameArtifact.Coin_Of_Luck)
        {
            this._SystemConfig.GamePlayConfigUIOverall.Time_Delay_Active_Button_Hiden *= 0.8f;
            return;
        }
        //Increase max life +1
        this._SystemConfig.PlayerSO.Max_Life++;
    }

}

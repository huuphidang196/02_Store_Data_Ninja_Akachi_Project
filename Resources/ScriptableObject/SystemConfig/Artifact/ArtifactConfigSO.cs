using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public enum TypeNameArtifact
{
    NoType = 0,

    Onimori = 1,
    Golden_Shuriken = 2,
    Sacred_Tsuka = 3,
    Coin_Of_Luck = 4,
}

[Serializable]
public class ArtifactItem
{
    public TypeNameArtifact TypeNameArtifact;
    public Sprite Sprite_Represent;
    public string Note_Detail_Artifact;
    public float Price_Artifact;
    public bool Unlock;

}


[CreateAssetMenu(fileName = "ArtifactConfigSO", menuName = "ScriptableObject/Configuration/ArtifactConfigSO", order = 1)]
public class ArtifactConfigSO : SystemConfigCtrl
{
    public List<ArtifactItem> List_ArtifactItems;

    public virtual ArtifactItem GetArtifactConfigSOByTypeName(TypeNameArtifact typeNameArtifact)
    {
        foreach (ArtifactItem item in this.List_ArtifactItems)
        {
            if (item.TypeNameArtifact == typeNameArtifact) return item;
        }

        return null;
    }    
}

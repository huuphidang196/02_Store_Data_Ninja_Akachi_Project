using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIArtifactItem : SurMonoBehaviour
{
    [SerializeField] protected Image _Image_Artifact_Represent;
    [SerializeField] protected Transform _Light_Selected;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadImageArtifactRepresent();
        this.LoadLightSelection();
    }

    protected virtual void LoadImageArtifactRepresent()
    {
        if (this._Image_Artifact_Represent != null) return;

        this._Image_Artifact_Represent = transform.Find("Image_Artifact_Represent").GetComponent<Image>();
        this._Image_Artifact_Represent.transform.localScale = Vector3.one;
        this._Image_Artifact_Represent.color = Color.black;
    }

    protected virtual void LoadLightSelection()
    {
        if (this._Light_Selected != null) return;

        this._Light_Selected = transform.Find("Light_Represent");
        this._Light_Selected.gameObject.SetActive(false);
    }

    protected override void Start()
    {
        base.Start();

        UICenterArtifactManager.Instance.Event_Changed_Selection += this.EventChangeSelectionArtifact;
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        UICenterArtifactManager.Instance.Event_Changed_Selection -= this.EventChangeSelectionArtifact;
    }
    protected virtual void EventChangeSelectionArtifact(int order)
    {
        bool sameOrder = order == this.transform.GetSiblingIndex();

        this._Light_Selected.gameObject.SetActive(sameOrder);

        this._Image_Artifact_Represent.transform.localScale = sameOrder ? 1.3f * Vector3.one : Vector3.one;
        ArtifactItem artifactItem = ArtifactSceneManager.Instance.SystemConfig.ArtifactConfigSO.List_ArtifactItems[this.transform.GetSiblingIndex()];
        this._Image_Artifact_Represent.color = artifactItem.Unlock ? Color.white : Color.black;

    }
}

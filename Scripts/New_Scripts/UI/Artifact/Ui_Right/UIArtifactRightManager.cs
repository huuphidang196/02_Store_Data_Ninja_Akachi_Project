using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UIArtifactRightManager : SurMonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI txt_Artifact_Detail;
    [SerializeField] protected TextMeshProUGUI txt_Artifact_Name_Selected;
    [SerializeField] protected Image _Image_Artifact_Represent;
    [SerializeField] protected TextMeshProUGUI txt_Detail_Artifact;
    [SerializeField] protected Transform _List_Button_Artifact;
    [SerializeField] protected TextMeshProUGUI txt_Unlock_Price;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadTextArtifactDetail();
        this.LoadTextArtifactSelected();
        this.LoadImageArtifactRepresent();
        this.LoadTextDetailArtifact();
        this.LoadButtonUnlockArtifact();
        this.LoadTextUnlockPrice();
    }

    protected virtual void LoadTextArtifactDetail()
    {
        if (this.txt_Artifact_Detail != null) return;

        this.txt_Artifact_Detail = transform.Find("Text_Artifact_Detail").GetComponent<TextMeshProUGUI>();
        this.txt_Artifact_Detail.raycastTarget = false;
    }

    protected virtual void LoadTextArtifactSelected()
    {
        if (this.txt_Artifact_Name_Selected != null) return;

        this.txt_Artifact_Name_Selected = transform.Find("Text_Artifact_Selected").GetComponent<TextMeshProUGUI>();
        this.txt_Artifact_Name_Selected.raycastTarget = false;
    }

    protected virtual void LoadImageArtifactRepresent()
    {
        if (this._Image_Artifact_Represent != null) return;

        this._Image_Artifact_Represent = transform.Find("Image_Artifact_Represent").GetComponent<Image>();
        this._Image_Artifact_Represent.raycastTarget = false;
    }

    protected virtual void LoadTextDetailArtifact()
    {
        if (this.txt_Detail_Artifact != null) return;

        this.txt_Detail_Artifact = transform.Find("Text_Detail_Artifact").GetComponent<TextMeshProUGUI>();
        this.txt_Detail_Artifact.raycastTarget = false;
    }

    protected virtual void LoadButtonUnlockArtifact()
    {
        if (this._List_Button_Artifact != null) return;

        this._List_Button_Artifact = transform.Find("List_Button_Artifact");

        this._Image_Artifact_Represent.color = Color.black;

        foreach (Transform item in this._List_Button_Artifact)
        {
            Button btn = item.GetComponent<Button>();
            btn.image.raycastTarget = true;
            item.gameObject.SetActive(false);
        }
       
    }
    protected virtual void LoadTextUnlockPrice()
    {
        if (this.txt_Unlock_Price != null) return;

        this.txt_Unlock_Price = transform.Find("Text_Unlock_Price").GetComponent<TextMeshProUGUI>();
        this.txt_Unlock_Price.gameObject.SetActive(false);
        this.txt_Unlock_Price.raycastTarget = false;
    }

    protected override void Start()
    {
        base.Start();

        UICenterArtifactManager.Instance.Event_Changed_Selection += this.ChangeSelectedArtifactItem;
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        UICenterArtifactManager.Instance.Event_Changed_Selection -= this.ChangeSelectedArtifactItem;
    }

    protected virtual void ChangeSelectedArtifactItem(int order)
    {
        ArtifactItem artifactItem = ArtifactSceneManager.Instance.SystemConfig.ArtifactConfigSO.List_ArtifactItems[order];

        this.txt_Artifact_Detail.text = artifactItem.Unlock ? "ARTIFACT ACQUIRED" : "ARTIFACT DETAIL";
        this.txt_Artifact_Name_Selected.text = string.Join(" ", artifactItem.TypeNameArtifact.ToString().Split('_')).Trim();

        this._Image_Artifact_Represent.sprite = artifactItem.Sprite_Represent;
        this._Image_Artifact_Represent.color = artifactItem.Unlock ? Color.white : Color.black;

        this.txt_Detail_Artifact.text = artifactItem.Note_Detail_Artifact;

        for (int i = 0; i < this._List_Button_Artifact.childCount; i++)
        {
            if (i != order)
            {
                this._List_Button_Artifact.GetChild(i).gameObject.SetActive(false);
                continue;
            }    

            this._List_Button_Artifact.GetChild(i).gameObject.SetActive(!artifactItem.Unlock);
        }

        this.txt_Unlock_Price.text = "Unlock " + artifactItem.Price_Artifact + " $";
        this.txt_Unlock_Price.gameObject.SetActive(!artifactItem.Unlock);

    }

}

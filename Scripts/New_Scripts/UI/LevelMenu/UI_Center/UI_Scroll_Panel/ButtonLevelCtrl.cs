using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonLevelCtrl : SurMonoBehaviour
{
    [SerializeField] protected int _Level_Rep;
    [SerializeField] protected Transform _Light_Selected;
    public Transform Light_Selected => _Light_Selected;

    [SerializeField] protected TextMeshProUGUI _txtLevelDisplay;
    [SerializeField] protected Image _Image_Lock;

    [SerializeField] protected Transform _Group_Stars;

    #region LoadComponents
    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadImageBG_Selected();
        this.LoadTextLevelDisplay();
        this.LoadImageLock();
        this.LoadGroupStars();
    }

    protected virtual void LoadImageBG_Selected()
    {
        if (this._Light_Selected != null) return;

        this._Light_Selected = transform.Find("Light_Selected");
    }

    protected virtual void LoadTextLevelDisplay()
    {
        if (this._txtLevelDisplay != null) return;

        this._txtLevelDisplay = transform.Find("btn_Level").GetComponentInChildren<TextMeshProUGUI>();

    }

    protected virtual void LoadImageLock()
    {
        if (this._Image_Lock != null) return;

        this._Image_Lock = transform.Find("Image_Lock").GetComponent<Image>();
    }
    protected virtual void LoadGroupStars()
    {
        if (this._Group_Stars != null) return;

        this._Group_Stars = transform.Find("Group_Stars").transform;

        foreach (Transform item in this._Group_Stars)
        {
            item.GetComponent<Image>().color = Color.black;
        }
    }

    #endregion

    protected override void OnEnable()
    {
        base.OnEnable();

        LevelMenuController.ClickedButtonLevel += this.ProcessEventClickedSelectLevel;
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        LevelMenuController.ClickedButtonLevel -= this.ProcessEventClickedSelectLevel;
    }
    protected virtual void ProcessEventClickedSelectLevel(int levelButton)
    {
        this._Light_Selected.gameObject.SetActive(false);

        bool isSelect = (this._Level_Rep == levelButton && this.CheckAllowByLevelUnlock(this._Level_Rep));
        this._Light_Selected.gameObject.SetActive(isSelect);

    }

    protected override void Start()
    {
        base.Start();

        this.SetElementOfButtonBegin();
    }

    protected virtual void SetElementOfButtonBegin()
    {
        //Set Level string
        string str_Level = transform.name.Substring(transform.name.LastIndexOf("_") + 1);
        this._Level_Rep = int.Parse(str_Level);

        this._txtLevelDisplay.text = this._Level_Rep != 16 ? this._Level_Rep + "" : "BOSS";
        this._txtLevelDisplay.color = this._Level_Rep != 16 ? Color.white : Color.red;
        if (this._Level_Rep == 16)
        {
            this._txtLevelDisplay.transform.parent.localScale *= 1.14f;
            this._txtLevelDisplay.transform.localScale *= 0.9f;
        }    

        this._Light_Selected.gameObject.SetActive(false);

        //Call open
        bool allowUnlock = this.CheckAllowByLevelUnlock(this._Level_Rep);
        this._Image_Lock.gameObject.SetActive(!allowUnlock);

        //Set Active true star
        int count = LevelMenuController.Instance.SystemConfig.GetStarMissionByLevel(this._Level_Rep) != null ? LevelMenuController.Instance.SystemConfig.GetStarMissionByLevel(this._Level_Rep).Count_Star_Acquired
            : 0;
        for (int i = 0; i < count; i++)
        {
            this._Group_Stars.GetChild(i).GetComponent<Image>().color = Color.white;
        }

    }

    protected virtual bool CheckAllowByLevelUnlock(int LevelCheck)
    {
        return LevelCheck <= LevelMenuController.Instance.SystemConfig.Level_Unlock;
    }


}

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIPanelSpecifySceneCtrl : SurMonoBehaviour
{
    [SerializeField] ButtonPlay _btnPlay;
    [SerializeField] protected Transform _Image_BG_Center_Rep_ModeLevel;
    public Transform Image_BG_Center_Rep_ModeLevel => this._Image_BG_Center_Rep_ModeLevel;

    [SerializeField] protected TextMeshProUGUI _txtNameOrderSceneMode;
    public TextMeshProUGUI TextNameOrderSceneMode => this._txtNameOrderSceneMode;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadButtonPlay();
        this.LoadImageBGCenterRepModeLevel();
        this.LoadNameOrderSceneMode();
    }

    protected virtual void LoadNameOrderSceneMode()
    {
        if (this._txtNameOrderSceneMode != null) return;

        this._txtNameOrderSceneMode = transform.Find("txtAction").GetComponent<TextMeshProUGUI>();
    }

    protected virtual void LoadImageBGCenterRepModeLevel()
    {
        if (this._Image_BG_Center_Rep_ModeLevel != null) return;

        this._Image_BG_Center_Rep_ModeLevel = transform.Find("Image_BG_Center_Rep_ModeLevel");
    }

    protected virtual void LoadButtonPlay()
    {
        if (this._btnPlay != null) return;

        this._btnPlay = transform.Find("btnEnter").GetComponent<ButtonPlay>();
    }

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
    protected virtual void ProcessEventClickedSelectLevel(int LevelButton)
    {
        //After Call Invoke 
        this._btnPlay.gameObject.SetActive(this.CheckAllowActive(LevelButton));

       // Debug.Log("LevelButton :" + LevelButton + ", bool " + this.CheckAllowActive(LevelButton));
    }

    protected virtual bool CheckAllowActive(int LevelCheck)
    {
        return LevelCheck <= LevelMenuController.Instance.SystemConfig.Level_Unlock;
    }

    protected override void Start()
    {
        base.Start();

        //false button Play
        this._btnPlay.gameObject.SetActive(false);
    }
}

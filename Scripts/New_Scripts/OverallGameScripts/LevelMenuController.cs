using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenuController : SystemController
{
    private static LevelMenuController m_instance;
    public static LevelMenuController Instance => m_instance;

    public static Action<int> ClickedButtonLevel;

    protected override void Awake()
    {
        base.Awake();

        if (m_instance != null) Debug.LogError("Allow only LevelMenuConttroler has been exist");

        m_instance = this;
    }
    public virtual void ClickSelectScenePlayByLevel(Transform buttonLevel)
    {
        //Sound
        string str_Level = buttonLevel.name.Substring(buttonLevel.name.LastIndexOf("_") + 1);
        int LevelButton = int.Parse(str_Level);

        ClickedButtonLevel?.Invoke(LevelButton); //Debug.Log("LevelButton " + LevelButton);

        if (this._SystemConfig.Level_Unlock < LevelButton) return;

        this._SystemConfig.Current_Level = LevelButton;

    }

    protected virtual string GetNameSceneCurrent() => this.GetNameSceneByOrder(this._SystemConfig.Current_Level);

    public virtual void StartLoadingScene()
    {
        string nameScene = this.GetNameSceneCurrent();

        StartCoroutine(LoadSceneWithWait(nameScene));
    }

   
    protected override void ConductActionWhileLoadingNewScene()
    {
        LevelMenuUIManager.Instance.LevelMenuUICtrl.UIBelowCtrl.Image_BG_Loading.gameObject.SetActive(true);
    }
    
}

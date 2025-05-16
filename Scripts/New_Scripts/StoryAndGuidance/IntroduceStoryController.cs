using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroduceStoryController : SystemController
{
    private static IntroduceStoryController m_instance;
    public static IntroduceStoryController Instance => m_instance;
    protected override void Awake()
    {
        base.Awake();

        if (m_instance != null) Debug.LogError("Allow only IntroduceStoryController has been exist");

        m_instance = this;
    }

    public virtual void FinishedIntroduceStory()
    {
        this._SystemConfig.isFinishedStory = true;
        SaveManager.Instance.SaveGame();

        Invoke(nameof(this.LoadLevelBegin), 0.5f);
    }   
    
    protected virtual void LoadLevelBegin()
    {
        this._SystemConfig.Current_Level = 1;

        string nameScene = "Level_01";

        StartCoroutine(LoadSceneWithWait(nameScene));
    }    

}

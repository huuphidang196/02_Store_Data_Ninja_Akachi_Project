using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryEndGameCtrl : SurMonoBehaviour
{
    private static StoryEndGameCtrl m_instance;
    public static StoryEndGameCtrl Instance => m_instance;

    protected override void Awake()
    {
        base.Awake();

        if (m_instance != null) Debug.LogError("Allow only StoryEndGameCtrl has been exist");

        m_instance = this;
    }

    protected override void Reset()
    {
        base.Reset();
        this.SetActiveAllChild(false);
    }

    public virtual void ConclusionEndGameByStory()
    {
        this.SetActiveAllChild(true);
    }   
    
    protected virtual void SetActiveAllChild(bool active)
    {
        foreach (Transform item in this.transform)
        {
            item.gameObject.SetActive(active);
        }
    }    
}

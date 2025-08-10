using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryEndGameManager : StoryIntroManager
{
    protected override void FinishStory()
    {
        //  Debug.Log("End Game");

        FinalGamePlayController.Final_Instance.ProcessAllEventSystemAfterEndGame();
    }
}

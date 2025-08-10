using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftSideUICenterManager : SurMonoBehaviour
{
    protected override void OnEnable()
    {
        base.OnEnable();

        bool isSceneFinal = GamePlayController.Instance.EndGame;

        foreach (Transform item in this.transform)
        {
            if (item.name != "Text_Final_Lose")
            {
                item.gameObject.SetActive(!isSceneFinal);
                continue;
            }

            item.gameObject.SetActive(isSceneFinal);
        }
    }
}

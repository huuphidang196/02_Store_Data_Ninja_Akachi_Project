using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICenterManager : SurMonoBehaviour
{
    private static UICenterManager _instance;
    public static UICenterManager Instance => _instance;

    [SerializeField] protected UICenterLevelMenuCtrl _UICenterLevelMenuCtrl;
    public UICenterLevelMenuCtrl UICenterLevelMenuCtrl => this._UICenterLevelMenuCtrl;

    protected override void Awake()
    {
        base.Awake();

        if (_instance != null) Debug.LogError("Only UICenterManager was allowed existed");

        _instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadUICenterLevelMenuCtrl();
    }

    protected override void ResetValue()
    {
        base.ResetValue();

        this.ResetBackGroundSceneBeginPlay();
    }

    protected virtual void ResetBackGroundSceneBeginPlay()
    {
        foreach (Transform item in this._UICenterLevelMenuCtrl.UICenterControlSceneLevel.UIPanelSpecifySceneCtrl.Image_BG_Center_Rep_ModeLevel)
        {
            item.gameObject.SetActive(item.GetSiblingIndex() == 0);
        }
        //Set Active Button
        this.SetActiveButtonAndTextByOrder(0);
    }
    protected virtual void LoadUICenterLevelMenuCtrl()
    {
        if (this._UICenterLevelMenuCtrl != null) return;

        this._UICenterLevelMenuCtrl = transform.parent.GetComponent<UICenterLevelMenuCtrl>();
    }
    protected override void Start()
    {
        base.Start();

        this.SpawnAllButtonLevel();
    }

    protected virtual void SpawnAllButtonLevel()
    {
        int maxCount = SystemController.CountScene;

        for (int i = 0; i < maxCount; i++)
        {
            Transform btnLevel = UIButtonLevelSpawner.Instance.Spawn(UIButtonLevelSpawner.NameButton, Vector3.zero, Quaternion.identity);

            btnLevel.name = UIButtonLevelSpawner.NameButton + "_" + (i + 1).ToString("D2");

            btnLevel.localScale = Vector3.one;

            btnLevel.gameObject.SetActive(true);

        }
    }

    public virtual void ProcessTransitImageBGRepresentLevelMode(bool isNext)
    {
        Transform BG_REP = this._UICenterLevelMenuCtrl.UICenterControlSceneLevel.UIPanelSpecifySceneCtrl.Image_BG_Center_Rep_ModeLevel;

        //Process transit BG
        foreach (Transform item in BG_REP)
        {
            if (item.gameObject.activeInHierarchy == false) continue;

            int t = item.GetSiblingIndex() + (isNext ? 1 : -1);

            BG_REP.GetChild(t).gameObject.SetActive(true);
            item.gameObject.SetActive(false);

            //Set Active Button
            this.SetActiveButtonAndTextByOrder(t);
            break;

        }
    }

    protected virtual void SetActiveButtonAndTextByOrder(int t)
    {
        //Set Active Button
        this._UICenterLevelMenuCtrl.UICenterControlSceneLevel.Btn_Back_Stage.gameObject.SetActive(t != 0);
        this._UICenterLevelMenuCtrl.UICenterControlSceneLevel.Btn_Next_Stage.gameObject.SetActive(t != (this._UICenterLevelMenuCtrl.UICenterControlSceneLevel.UIPanelSpecifySceneCtrl.Image_BG_Center_Rep_ModeLevel.childCount - 1));

        this._UICenterLevelMenuCtrl.UICenterControlSceneLevel.UIPanelSpecifySceneCtrl.TextNameOrderSceneMode.text = "ACT " + (t + 1);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBelowMainMenuSceneManager : SurMonoBehaviour
{
    private static UIBelowMainMenuSceneManager _instance;
    public static UIBelowMainMenuSceneManager Instance => _instance;

    [SerializeField] protected Transform _Button_FreeDiamonds;
    [SerializeField] protected bool isInternal_Active = true;

    protected override void Awake()
    {
        base.Awake();

        if (_instance != null) Debug.LogError("Only UIBelowMainMenuSceneManager was allowed existed");

        _instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadButtonFreeDiamonds();
    }

    protected virtual void LoadButtonFreeDiamonds()
    {
        if (this._Button_FreeDiamonds != null) return;

        this._Button_FreeDiamonds = transform.Find("btnWatchAdsGift");
    }
    protected virtual void Update()
    {
        if (this.GetBoolActiveFreeDiamonds() == this._Button_FreeDiamonds.gameObject.activeInHierarchy) return;

        this._Button_FreeDiamonds.gameObject.SetActive(this.GetBoolActiveFreeDiamonds());
    }
    
    protected virtual bool GetBoolActiveFreeDiamonds()
    {
        return (GoogleAdsManager.Instance.AdmobAdsManager.AllowButttonActive && this.isInternal_Active);
    }    
    public virtual void ProcessWatchAdsFreeDiamonds()
    {
        this.isInternal_Active = false;

        // Gán global action trước khi show ads
        GoogleAdsManager.Instance.AdmobAdsManager.OnAdClosedGlobal = () =>
        {
            //Set true internal bool
            this.isInternal_Active = true;
        };

        GoogleAdsManager.Instance.AdmobAdsManager.WatchVideoAdsEarnMoney();

    }

}

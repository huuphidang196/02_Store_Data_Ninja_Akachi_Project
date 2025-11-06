using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginSceneController : SystemController
{
    private static BeginSceneController m_instance;
    public static BeginSceneController Instance => m_instance;

    [SerializeField] protected Transform _Panel_ADS_Setting;
    protected override void Awake()
    {
        base.Awake();

        if (m_instance != null) Debug.LogError("Allow only BeginSceneController  been exist");

        m_instance = this;
    }

    protected override void Start()
    {
        base.Start();

        Invoke(nameof(this.QuestionUserAcceptADSSetting), 0.5f);
    }
    protected virtual void QuestionUserAcceptADSSetting()
    {
        if (SaveManager.Instance.DataSaved.systemConfigData.isAcceptAdsSetting) return;

        this._Panel_ADS_Setting.gameObject.SetActive(true);
    }    
}

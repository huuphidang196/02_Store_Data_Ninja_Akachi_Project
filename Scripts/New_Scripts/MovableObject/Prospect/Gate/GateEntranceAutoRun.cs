using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EntranceCheck
{
    public Transform Gate;
    public bool isPassed;
    public EntranceCheck(Transform gate, bool passed)
    {
        Gate = gate;
        isPassed = passed;
    }
}

public class GateEntranceAutoRun : SurMonoBehaviour
{
    private static GateEntranceAutoRun m_instance;
    public static GateEntranceAutoRun Instance => m_instance;

    [SerializeField] protected bool isEntranceAuto = false;
    public bool IsEntranceAuto => this.isEntranceAuto;

    [SerializeField] protected bool wasCom_Mission = false;
    public bool WasCom_Mission => this.wasCom_Mission;

    [SerializeField] protected float _Distance_ModeOn;

    [SerializeField] protected List<EntranceCheck> _Gate_Entrance;
    public List<EntranceCheck> Gate_Entrance => this._Gate_Entrance;

    protected override void Awake()
    {
        base.Awake();

        if (m_instance != null) Debug.LogError("Allow only GateEntranceAutoRun has been exist");

        m_instance = this;
    }

    protected override void ResetValue()
    {
        base.ResetValue();

        this.isEntranceAuto = false;
        this.wasCom_Mission = false;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadGateEntranceEnd();
    }

    protected virtual void LoadGateEntranceEnd()
    {
        if (this._Gate_Entrance.Count > 0) return;

        foreach (Transform item in this.transform)
        {
            EntranceCheck entranceCheck = new EntranceCheck(item, false);
            this._Gate_Entrance.Add(entranceCheck);
        }
        // Sắp xếp danh sách theo position.x
        this._Gate_Entrance.Sort((a, b) => a.Gate.position.x.CompareTo(b.Gate.position.x));
    }

    protected override void Start()
    {
        base.Start();

        this._Distance_ModeOn = GamePlayController.Instance.SystemConfig.GameConfigController.Distance_ModeOn;
    }

    protected virtual void FixedUpdate()
    {
        if (this._Gate_Entrance.Count == 0) return;

        if (PlayerCtrl.Instance.transform.position.x - this._Gate_Entrance[this._Gate_Entrance.Count - 1].Gate.position.x >= 0)
        {
            this.wasCom_Mission = true;
            // Set Level Unlock
            SystemController.Sys_Instance.SystemConfig.SetLevelUnlock();
        }

        foreach (EntranceCheck item in this._Gate_Entrance)
        {
            if (item.isPassed) continue;

            if (this.CheckDistanceAutoMode(item.Gate))
            {
                this.isEntranceAuto = true;
                return;
            }
            item.isPassed = PlayerCtrl.Instance.transform.position.x > item.Gate.position.x + 7f;
        }
        this.isEntranceAuto = false;
    }

    protected virtual bool CheckDistanceAutoMode(Transform gate)
    {
        float distance = gate.position.x - PlayerCtrl.Instance.transform.position.x;
        return distance < this._Distance_ModeOn
            && distance > -7f;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UICenterArtifactManager : SurMonoBehaviour
{
    public Action<int> Event_Changed_Selection;

    private static UICenterArtifactManager _instance;
    public static UICenterArtifactManager Instance => _instance;

    [SerializeField] protected int _Order_Artifact_Selected = 0;
    public int Order_Artifact_Selected => this._Order_Artifact_Selected;

    protected override void Awake()
    {
        base.Awake();

        if (_instance != null) Debug.LogError("Allow only UICenterArtifactManager has been exist");

        _instance = this;
    }

    protected override void Start()
    {
        base.Start();

        Invoke(nameof(this.BeginArtifactChangeByFirst), 0.25f);
    }

    protected virtual void BeginArtifactChangeByFirst() => this.ChangeSelectItemArtifact(0);
    public virtual void ChangeSelectItemArtifact(int order)
    {
        this._Order_Artifact_Selected = order;
        Event_Changed_Selection?.Invoke(order);
    }
}

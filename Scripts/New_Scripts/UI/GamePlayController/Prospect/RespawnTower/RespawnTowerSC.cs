using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnTowerSC : SurMonoBehaviour
{
    private static RespawnTowerSC _instance;
    public static RespawnTowerSC Instance => _instance;

    [SerializeField] protected List<Transform> _List_RespawnTowers;

    protected override void Awake()
    {
        base.Awake();

        if (_instance != null) Debug.LogError("Only RespawnTowerSC was allowed existed");

        _instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadAllRespawnTower();
    }

    protected virtual void LoadAllRespawnTower()
    {
        if (this._List_RespawnTowers.Count > 0) return;

        foreach (Transform respawnTower in transform)
        {
            this._List_RespawnTowers.Add(respawnTower);
        }
    }

    public virtual Vector2 GetPositionRespawnTowerPlayerDead()
    {
        Vector3 playerPos = PlayerCtrl.Instance.transform.position;

        // Transform secondTower = this._List_RespawnTowers[1];
        // if (playerPos.x < secondTower.position.x) return this._List_RespawnTowers[0].position + new Vector3(0.5f, 0.5f, 0);

        for (int i = this._List_RespawnTowers.Count - 1 ; i >= 0; i--)
        {
            RespawnTowerCtrl respawnTowerCtrl = this._List_RespawnTowers[i].GetComponent<RespawnTowerCtrl>();

            if (respawnTowerCtrl == null) continue;

            if (!respawnTowerCtrl.LightRespawnTower.WasTurned) continue;

            return new Vector3(respawnTowerCtrl.transform.position.x + 1, respawnTowerCtrl.transform.position.y + 1, playerPos.z);
        }

        // There is not any tower has pos.x > player
        return this._List_RespawnTowers[0].position + new Vector3(1f, 1f, 0);

    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LanceTrapEventsAutoOn : EventScenePlayAutoOnByDistancePlayer
{
    [SerializeField] protected List<ObjectCtrl> _LanceObjects; // Danh sách các Lance
    [SerializeField] protected float totalTime = 3f; // Tốc độ nâng lên
    [SerializeField] protected float raiseHeight = 3.7f; // Độ cao nâng lên
    [SerializeField] protected List<Vector3> _StartPositions; // Lưu vị trí ban đầu của các lance
    [SerializeField] protected List<Vector3> _TargetPositions; // Lưu vị trí sau khi bật lên

    protected override void ResetValue()
    {
        base.ResetValue();
        this.activated = false;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadLanceObjects();
    }

    protected virtual void LoadLanceObjects()
    {
        if (this._LanceObjects.Count > 0) return;

        foreach (Transform item in this.transform)
        {
            ObjectCtrl objCtrl = item.GetComponent<ObjectCtrl>();
            this._LanceObjects.Add(objCtrl);
        }
    
    }
    protected virtual IEnumerator RaiseLances()
    {
        float timePerLance = totalTime / this._LanceObjects.Count; // Thời gian cho mỗi Lance

        for (int i = 0; i < this._LanceObjects.Count; i++)
        {
            float elapsedTime = 0;
            Vector3 startPos = this._StartPositions[i];
            Vector3 targetPos = this._TargetPositions[i];

            // Di chuyển từ từ đến vị trí target
            while (elapsedTime < timePerLance)
            {
                elapsedTime += Time.fixedDeltaTime;
                float t = elapsedTime / timePerLance;
                this._LanceObjects[i].transform.position = Vector3.Lerp(startPos, targetPos, t);
                yield return null;
            }

            // Đảm bảo vị trí cuối cùng chính xác
            this._LanceObjects[i].transform.position = targetPos;
            this.SpawnVFXWeaponByName(targetPos + this.GetOffSetSpawnVFX(this._LanceObjects[i].transform));
        }
    }

    protected abstract Vector3 GetOffSetSpawnVFX(Transform lance);
    protected virtual void SpawnVFXWeaponByName(Vector3 lanceStartpos)
    {
        Transform vfx_Need = VFXObjectSpawner.Instance.Spawn(this.GetNamVFXSpawn(), lanceStartpos, Quaternion.identity);

        if (vfx_Need == null) return;

        vfx_Need.localScale = Vector3.one;
        vfx_Need.gameObject.SetActive(true);

    }

    protected virtual  string GetNamVFXSpawn()
    {
        return VFXObjectSpawner.VFX_Ground_Emit;
    }

    protected override void ConductActionEvents()
    {
        StartCoroutine(RaiseLances());
    }

}

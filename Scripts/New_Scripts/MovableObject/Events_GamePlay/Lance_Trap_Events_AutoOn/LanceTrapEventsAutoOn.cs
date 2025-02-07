using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanceTrapEventsAutoOn : SurMonoBehaviour
{
    [SerializeField] protected List<ObjectCtrl> _LanceObjects; // Danh sách các Lance
    [SerializeField] protected float raiseHeight = 3f; // Độ cao nâng lên
    [SerializeField] protected float totalTime = 3f; // Tốc độ nâng lên
    [SerializeField] protected float activationDistance = 5f; // Khoảng cách để kích hoạt

    [SerializeField] protected List<Vector3> _StartPositions; // Lưu vị trí ban đầu của các lance
    [SerializeField] protected List<Vector3> _TargetPositions; // Lưu vị trí sau khi bật lên
    [SerializeField] protected bool activated = false; // Đánh dấu đã kích hoạt hay chưa

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

        this._StartPositions.Add(this._LanceObjects[0].transform.position);
        this._TargetPositions.Add(
               new Vector3(this._LanceObjects[0].transform.position.x, this.transform.GetChild(this.transform.childCount - 1).position.y + raiseHeight, 0));

        for (int i = 1; i < this._LanceObjects.Count; i++)
        {
            this._LanceObjects[i].transform.position = 
                new Vector3(this._LanceObjects[i - 1].transform.position.x - 0.5f, this._LanceObjects[i].transform.position.y, 0);
            this._StartPositions.Add(this._LanceObjects[i].transform.position);
            this._TargetPositions.Add(
                new Vector3(this._LanceObjects[i].transform.position.x, this.transform.GetChild(this.transform.childCount - 1).position.y + raiseHeight, 0));
        }
    }

    protected virtual void Update()
    {
        // Kiểm tra khoảng cách với Player
        if (activated) return;

        float distance = this.transform.position.x - PlayerCtrl.Instance.transform.position.x;
        if (distance < activationDistance)
        {
            StartCoroutine(RaiseLances());
            activated = true;
        }

    }

    protected IEnumerator RaiseLances()
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
                elapsedTime += Time.deltaTime;
                float t = elapsedTime / timePerLance;
                this._LanceObjects[i].transform.position = Vector3.Lerp(startPos, targetPos, t);
                yield return null;
            }

            // Đảm bảo vị trí cuối cùng chính xác
            this._LanceObjects[i].transform.position = targetPos;
        }
    }
}


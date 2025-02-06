using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanceTrapEventsAutoOn : SurMonoBehaviour
{
    [SerializeField] protected List<Transform> _LanceObjects; // Danh sách các Lance
    [SerializeField] protected float raiseHeight = 3f; // Độ cao nâng lên
    [SerializeField] protected float raiseSpeed = 2f; // Tốc độ nâng lên
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
            this._LanceObjects.Add(item);
            this._StartPositions.Add(item.position);
            this._TargetPositions.Add(this.transform.GetChild(this.transform.childCount - 1).position + Vector3.up * raiseHeight);
        }

        for (int i = 1; i < this._LanceObjects.Count; i++)
        {
            this._LanceObjects[i].position = new Vector3(this._LanceObjects[i - 1].position.x - 0.5f, this._LanceObjects[i].position.y, 0);
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
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime * raiseSpeed; // Điều chỉnh tốc độ

            for (int i = 0; i < this._LanceObjects.Count; i++)
            {
                this._LanceObjects[i].position = Vector3.Lerp(_StartPositions[i], _TargetPositions[i], t);
            }

            yield return null; // Chờ frame tiếp theo
        }
    }
}

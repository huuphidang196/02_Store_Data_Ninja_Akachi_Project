using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjCircularMovement : ObjectAbstract
{
    [SerializeField] protected float radius = 5f;
    [SerializeField] protected float angularSpeed = 1f;
    [SerializeField] protected float initialAngleDeg = 0f;

    [SerializeField] protected float angle;
    [SerializeField] protected Vector2 center;

    protected override void Start()
    {
        // Set center tại vị trí ban đầu
        center = this._ObjectCtrl.transform.position;

        // Tính vị trí bắt đầu trên quỹ đạo dựa trên initialAngleDeg
        float rad = initialAngleDeg * Mathf.Deg2Rad;
        float x = center.x + radius * Mathf.Cos(rad);
        float y = center.y + radius * Mathf.Sin(rad);

        this._ObjectCtrl.transform.position = new Vector3(x, y, this._ObjectCtrl.transform.position.z);

        // Khi chạy game, giữ nguyên center đã thiết lập
        angle = initialAngleDeg * Mathf.Deg2Rad;
    }

    protected virtual void Update()
    {
        angle -= angularSpeed * Time.deltaTime;

        float x = center.x + radius * Mathf.Cos(angle);
        float y = center.y + radius * Mathf.Sin(angle);

        this._ObjectCtrl.transform.position = new Vector3(x, y, this._ObjectCtrl.transform.position.z);
    }

}

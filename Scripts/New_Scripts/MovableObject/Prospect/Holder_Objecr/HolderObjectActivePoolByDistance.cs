using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HolderObjectActivePoolByDistance : SurMonoBehaviour
{
    protected override void ResetValue()
    {
        base.ResetValue();

        this.SortAllObjectsByPositionX();
    }

    protected virtual void SortAllObjectsByPositionX()
    {
        if (this.transform.childCount == 0) return;

        // Lấy danh sách các đối tượng con của holder
        var children = this.transform.Cast<Transform>().ToList();

        // Sắp xếp danh sách theo vị trí x
        children = children.OrderBy(child => child.position.x).ToList();

        // Cập nhật lại SiblingIndex cho các đối tượng
        for (int i = 0; i < children.Count; i++)
        {
            children[i].SetSiblingIndex(i);
            children[i].gameObject.SetActive(false);
        }
    }

    protected virtual void FixedUpdate()
    {
        if (GamePlayController.Instance.PauseGame) return;

        if (this.transform.childCount == 0) return;

        this.ActiveAllObjectsWithinTheScopeOfPlayer();
    }

    protected virtual void ActiveAllObjectsWithinTheScopeOfPlayer()
    {
        foreach (Transform enemy in this.transform)
        {
            bool withinScope = this.CheckObjectWithinScopePlayer(enemy);
            //Debug.Log("Name: " + enemy.name + ", d = " + Mathf.Abs(enemy.position.x - PlayerCtrl.Instance.transform.position.x));
            if (!withinScope) continue;

            enemy.gameObject.SetActive(withinScope);
        }
    }

    protected virtual bool CheckObjectWithinScopePlayer(Transform enemy)
    {
        float distanceX = Mathf.Abs(enemy.position.x - PlayerCtrl.Instance.transform.position.x);

        return distanceX <= this.GetActiveDistance();
    }

    protected virtual float GetActiveDistance()
    {
        return GamePlayController.Instance.Distance_Active_Enemies;
    }
}

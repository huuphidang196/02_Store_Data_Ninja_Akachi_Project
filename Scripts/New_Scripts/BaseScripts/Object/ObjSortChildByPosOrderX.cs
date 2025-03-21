using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjSortChildByPosOrderX : SurMonoBehaviour
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
        }
    }
}

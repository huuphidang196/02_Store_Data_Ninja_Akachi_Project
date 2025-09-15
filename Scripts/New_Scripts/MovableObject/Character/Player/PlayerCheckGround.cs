using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckGround : CharacterCheckGround
{
    //[SerializeField] protected bool isContained;
    //public bool IsContained => this.isContained;

    //protected override void Update()
    //{
    //    base.Update();

    //    this.isContained = this.isGround && this.CheckContainer();
    //}

    public virtual bool CheckContainer()
    {
        // Lấy tất cả collider trong bán kính
        Collider2D[] colliders = Physics2D.OverlapCircleAll(
            this._GroundCheck.position,
            this._Radius_Check,
            this._GroundLayer
        );

        // Duyệt qua từng collider
        foreach (Collider2D col in colliders)
        {
            if (col.gameObject.name == "Obj_Container_Player")
            {
                return true; // tìm thấy thì trả về true
            }
        }

        return false; // không có thì trả về false
    }

    
}

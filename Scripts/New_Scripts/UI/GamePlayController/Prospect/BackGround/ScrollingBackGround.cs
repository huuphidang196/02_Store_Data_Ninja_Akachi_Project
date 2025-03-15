using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackGround : SurMonoBehaviour
{
    [SerializeField] protected float _Speed = 0.2f;
    [SerializeField] protected Renderer _BG;

    protected virtual void Update()
    {
        this._BG.material.mainTextureOffset += new Vector2(this._Speed * Time.deltaTime, 0);
    }    

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class BaseText : SurMonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI _BaseText;

    [SerializeField] protected string _Content;
    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadBaseText();
    }

    protected virtual void LoadBaseText()
    {
        if (this._BaseText != null) return;

        this._BaseText = GetComponentInChildren<TextMeshProUGUI>();
    }

    public virtual void SetContent(string content) => this._Content = content;

    protected virtual void FixedUpdate()
    {
        this._BaseText.text = this._Content;
    }    
}

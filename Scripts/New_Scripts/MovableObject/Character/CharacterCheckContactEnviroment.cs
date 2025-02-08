using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCheckContactEnviroment : CharacterAbstract
{
    [SerializeField] protected CharacterCheckForward _CharacterCheckForward;
    public CharacterCheckForward CharacterCheckForward => _CharacterCheckForward;

    [SerializeField] protected CharacterCheckGround _CharacterCheckGround;
    public CharacterCheckGround CharacterCheckGround => _CharacterCheckGround;

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadCharacterCheckForward();
        this.LoadCharacterCheckGround();
    }

    protected virtual void LoadCharacterCheckForward()
    {
        if (this._CharacterCheckForward != null) return;

        this._CharacterCheckForward = GetComponentInChildren<CharacterCheckForward>();
    }

    protected virtual void LoadCharacterCheckGround()
    {
        if (this._CharacterCheckGround != null) return;

        this._CharacterCheckGround = GetComponentInChildren<CharacterCheckGround>();
    }

}

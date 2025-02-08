using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckContactEnviroment : CharacterCheckContactEnviroment
{
    public PlayerCheckForward PlayerCheckForward => this._CharacterCheckForward as PlayerCheckForward;

    public PlayerCheckGround PlayerCheckGround => this._CharacterCheckGround as PlayerCheckGround;

   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCheckContactEnviroment : CharacterCheckContactEnviroment
{
    public EnemyCtrl EnemyCtrl => this._CharacterCtrl as EnemyCtrl;
    public EnemyCheckForward EnemyCheckForward => this._CharacterCheckForward as EnemyCheckForward;

}

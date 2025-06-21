using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCheckContactEnviroment : EnemyCheckContactEnviroment
{
    public BossCtrl BossCtrl => this._CharacterCtrl as BossCtrl;
    public BossCheckForward BossCheckForward => this._CharacterCheckForward as BossCheckForward;
}

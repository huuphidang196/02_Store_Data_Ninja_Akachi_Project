using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemySO", menuName = "ScriptableObject/MovableObjScriptableObject/CharacterScriptableObject/EnemySO")]
public class EnemySO : CharacterScriptableObject
{
    [Header("EnemySO")]

    public float Time_Delay_Attack = 1.5f;
    public float Distance_Attack_Player = 0.3f;

}

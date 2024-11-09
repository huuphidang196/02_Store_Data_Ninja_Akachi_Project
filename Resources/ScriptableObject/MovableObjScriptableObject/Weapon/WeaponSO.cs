using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponSO", menuName = "ScriptableObject/MovableObjScriptableObject/WeaponSO")]
public class WeaponSO : MObjScriptableObject
{
    [Header("WeaponSO")]
    public float Time_Delay_Disable = 0.5f;
    public float Damage_Send = 9999f;
}

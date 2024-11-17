using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ItemUnit
{
    public TypeItem TypeItem;

    public float Value;

    public ItemUnit() {; }
}

[CreateAssetMenu(fileName = "GameConfigController", menuName = "ScriptableObject/Configuration/GameConfigController", order = 1)]
public class GameConfigController : SystemConfigCtrl
{
    public float Distance_Active_Enemies;

    public ItemUnit Gold_Rivival_Begin;
    public float Compensation_Gold_Rivive;

    public ItemUnit Diamond_Rivival_Begin;
    public float Compensation_Diamond_Rivive;
}

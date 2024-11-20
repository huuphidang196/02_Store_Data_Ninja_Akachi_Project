using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

[Serializable]
public enum TypeItem
{
    NoType = 0,

    Gold = 1,
    Diamond = 2,

}

[Serializable]
public class ItemDropUnit
{
    public MinMaxPair RangeValueDrop;

    protected ItemUnit _ItemUnit;
    public ItemUnit ItemUnit
    {
        get
        {
            this._ItemUnit = new ItemUnit(Mathf.Round(Random.Range(this.RangeValueDrop.Min, this.RangeValueDrop.Max)));
            return this._ItemUnit;
        }
        set => this._ItemUnit = value;
    }
    public ItemDropUnit() {; }
    // Constructor
    public ItemDropUnit(MinMaxPair range)
    {
        this.RangeValueDrop = range;
    }

}

[Serializable]
public class ItemUnit
{
    public TypeItem TypeItem;

    public float Value;

    public ItemUnit() {; }
    public ItemUnit(float value)
    {
        this.Value = value;
    }

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

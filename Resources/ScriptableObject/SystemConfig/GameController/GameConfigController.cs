using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

[Serializable]
public enum TypeItemMoney
{
    NoType = 0,

    Gold = 1,
    Diamond = 2,
    Star_Mission = 3,
}

[Serializable]
public class ItemDropUnit
{
    public MinMaxPair RangeValueDrop;

    [SerializeField] protected ItemUnit _ItemUnit;
    public ItemUnit ItemUnit
    {
        get
        {
            if (this._ItemUnit.Value == 0) this._ItemUnit = new ItemUnit(Mathf.Round(Random.Range(this.RangeValueDrop.Min, this.RangeValueDrop.Max)), this._ItemUnit.TypeItem);
            return this._ItemUnit;
        }
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
    public TypeItemMoney TypeItem;

    public float Value;

    public ItemUnit() {; }
    public ItemUnit(float value, TypeItemMoney typeItem)
    {
        this.TypeItem = typeItem;
        this.Value = value;
    }

}

[Serializable]
public class ItemMoneyUnit
{
    public ItemUnit ItemUnit;
    public Sprite Sprite_Represent_Money;
    public Color Color_Text
    {
        get
        {
            if (this.ItemUnit.TypeItem == TypeItemMoney.NoType) return Color.gray;

            if(this.ItemUnit.TypeItem == TypeItemMoney.Gold) return Color.yellow;

            return Color.cyan;
        }
    }
}

[Serializable]
public class StarMissionLevel
{
    public int Level_Mission;
    public int Count_Star_Acquired;

    public StarMissionLevel() {; }
    public StarMissionLevel(int level, int Count)
    {
        this.Level_Mission = level;
        this.Count_Star_Acquired = (Count > 3) ? 3 : Count;
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

    public int Order_Music_BG = 0;
    public float Distance_ModeOn = 8f;

   

}

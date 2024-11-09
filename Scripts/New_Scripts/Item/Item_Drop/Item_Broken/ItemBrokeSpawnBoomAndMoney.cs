using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBrokeSpawnBoomAndMoney : ItemBrokeSpawnMoney
{
    [Header("ItemBrokeSpawnBoomAndMoney")]
    [SerializeField, Range(0f, 1f)]
    protected float _Money_SpawnRate = 0.4f; // Tỉ lệ spawn cho item1, mặc định là 40%
    protected override void SpawnMoneyBag()
    {
        float randomValue = Random.Range(0f, 1f);
        string nameBox = (randomValue < this._Money_SpawnRate) ? ItemDropSpawner.Name_Gold_Bag : ItemDropSpawner.Name_Boom;
        this.SpawnBoxContainMoney(nameBox);
    }
}

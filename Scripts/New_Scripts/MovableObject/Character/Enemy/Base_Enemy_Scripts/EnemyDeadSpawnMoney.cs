using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeadSpawnMoney : EnemyAbstract
{
    [Header("EnemyDeadSpawnMoney")]
    [SerializeField, Range(0f, 1f)]
    protected float _Gold_SpawnRate = 0.4f; // Tỉ lệ spawn cho item1, mặc định là 40%

    [SerializeField, Range(0f, 0.5f)]
    protected float _Diamond_SpawnRate = 0.1f;
    public virtual void SpawnMoneyBag()
    {
        float randomValue = Random.Range(0f, 1f);
        string nameBox = "";

        if (randomValue > this._Gold_SpawnRate) return;

        nameBox = (randomValue <= this._Diamond_SpawnRate) ? ItemDropSpawner.Name_Diamond_Bag : ItemDropSpawner.Name_Gold_Bag;

        this.SpawnBoxContainMoney(nameBox);
    }
    protected virtual void SpawnBoxContainMoney(string nameBox)
    {
        Transform box = ItemDropSpawner.Instance.Spawn(nameBox, this.EnemyCtrl.transform.position + new Vector3(0, 1.5f, 0), Quaternion.identity);

        box.gameObject.name = nameBox;
        box.localScale = Vector3.one;
        box.gameObject.SetActive(true);
    }
}

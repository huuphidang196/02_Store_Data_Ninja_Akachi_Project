using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "SkinHidenModeSO", menuName = "ScriptableObject/Configuration/Shop/DisguiseConfigSO", order = 1)]
public class DisguiseConfigSO : ScriptableObject
{
    public int Order_Skin_Equipped;

    public List<SkinHidenMode> Skins_Hiden_Mode;

    public SkinHidenMode SkinHidenMode_Using => this.Skins_Hiden_Mode[Order_Skin_Equipped];


}

[Serializable]
public class SkinHidenMode
{
    public BaseDataUnlock BaseDataUnlock;
    public ItemMoneyUnit ItemMoneyUnit;
    public Sprite Sprite_Rep_Skin;

}
[Serializable]
public class BaseDataUnlock
{
    public string Name_Data;
    public bool Unlock;

    public BaseDataUnlock(string name, bool unlock)
    {
        this.Name_Data = name;
        this.Unlock = unlock;
    }
}

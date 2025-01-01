using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "SkinHidenModeSO", menuName = "ScriptableObject/Configuration/Shop/DisguiseConfigSO", order = 1)]
public class DisguiseConfigSO : ScriptableObject
{
    public int _Order_Skin_Equipped;

    public List<SkinHidenMode> Skins_Hiden_Mode;
}

[Serializable]
public class SkinHidenMode
{
    public string Name_Skin_Mode;
    public bool Unlock;
    public ItemMoneyUnit ItemMoneyUnit;
    public Sprite Sprite_Rep_Skin;

}

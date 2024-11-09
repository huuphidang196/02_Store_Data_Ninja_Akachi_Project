using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GamePlayConfigUIOverall", menuName = "ScriptableObject/Configuration/GamePlayConfigUIOverall", order = 2)]
public class GamePlayConfigUIOverall : SystemConfigCtrl
{
    public float Time_Delay_Button_Hiden = 5f;
    public float Time_Delay_Active_Button_Hiden = 12f;
    public float Time_Delay_Active_Button_Attack_Throw = 0.5f;
    public float Time_Delay_Active_Button_Attack_Dashing = 5f;
}

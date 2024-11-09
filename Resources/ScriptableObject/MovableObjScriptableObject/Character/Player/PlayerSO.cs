using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSO", menuName = "ScriptableObject/MovableObjScriptableObject/CharacterScriptableObject/PlayerSO")]
public class PlayerSO : CharacterScriptableObject
{
    [Header("PlayerSO")]
    public float Time_Delay_Hiden = 5f;
    public float JumpingPower = 17f;
    public float WallSlidingSpeed = 3f;
    public float WallJumpingTime = 0.2f;
    public float WallJumpingDuration = 0.4f;
    public float DashingPower = 35f;
    public float DashingTime = 0.3f;
    public float Speed_Hiding_Horizontal = 1.5f;
    public float Radius_Check = 0.1f;

}
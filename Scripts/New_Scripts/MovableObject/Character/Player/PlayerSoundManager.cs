using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundManager : CharacterMainSoundManager
{
    public PlayerCtrl PlayerCtrl => this._ObjectCtrl as PlayerCtrl;

    //[Header("PlayerSoundManager")]

    protected override void OnEnable()
    {
        base.OnEnable();
        //  InputManager.PressJumpButton_Event += this.PlaySoundJump;
        InputManager.PressDashingButton_Event += this.PlaySoundDashing;
        InputManager.PressHiddenButton_Event += this.PlaySoundHidden;
        InputManager.PressAttackThrowButton_Event += this.PlaySoundAttackThrow;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        //   InputManager.PressJumpButton_Event -= this.PlaySoundJump;
        InputManager.PressDashingButton_Event -= this.PlaySoundDashing;
        InputManager.PressHiddenButton_Event -= this.PlaySoundHidden;
        InputManager.PressAttackThrowButton_Event -= this.PlaySoundAttackThrow;
    }

    protected virtual void Update()
    {
        if (this.PlayerCtrl.PlayerAnimation.Rivive_Again_Ani)
        {
            this.PlayeSoundWithNameAction("Player_Rivival_Sound");
            return;
        }

        if (this.PlayerCtrl.PlayerAnimation.IsDead)//
        {
            this.PlayeSoundWithNameAction("Player_Dead_Sound");
            return;
        }

        if (this.PlayerCtrl.PlayerMovement.IsDashing)
        {
            //this.PlayeSoundWithNameAction("Player_Dashing");
            return;
        }

        if (this.PlayerCtrl.PlayerMovement.Rigidbody2D.velocity.y > 0)//
        {
            // this.PlayeSoundWithNameAction("Player_Jump");
            return;
        }

        if (this._AudioSource.isPlaying) return;

        this._AudioSource.clip = null;
        this._AudioSource.Stop();

        if (this.PlayerCtrl.PlayerAnimation.Wall_Sliding_Ani)
        {
            this.PlayeSoundWithNameAction("Player_Wall_Sliding_Sound");
            return;
        }

        if (this.PlayerCtrl.PlayerAnimation.Run_Ani && !this.PlayerCtrl.PlayerMovement.IsStunned)
        {
            this.PlayeSoundWithNameAction("Player_Run_Sound");
            return;
        }

    }

    public virtual void PlaySoundJump(bool isFirst) => this.PlayeSoundWithNameAction(isFirst ? "Player_Jump_Sound" : "Player_Double_Jump_Sound");
    public virtual void PlaySoundDashing() => this.PlayeSoundWithNameAction("Player_Dashing_Sound");
    protected virtual void PlaySoundHidden() => this.PlayeSoundWithNameAction("Player_Hidden_Sound");
    protected virtual void PlaySoundAttackThrow() => this.PlayeSoundWithNameAction("Player_Attack_Throw_Sound");

    protected override void PlayeSoundWithNameAction(string nameAction)
    {
        AudioClip clip = GamePlayController.Instance.SystemConfig.SoundCtrlSO.SoundPlayerSO.GetAudioClipByNameAction(nameAction);
        this.PlaySound(clip);
    }

    protected override bool CheckOrderSound(AudioClip clip)
    {
        if (this._AudioSource.clip == null) return true;
        // Chuyển chuỗi thành enum
        PlayerOrderSounAction soundCheck = (PlayerOrderSounAction)Enum.Parse(typeof(PlayerOrderSounAction), clip.name, true);
        PlayerOrderSounAction currentSound = (PlayerOrderSounAction)Enum.Parse(typeof(PlayerOrderSounAction), this._AudioSource.clip.name, true);

        return soundCheck > currentSound;
    }

}

[Serializable]
public enum PlayerOrderSounAction
{
    Player_Run_Sound = 1,

    Player_Wall_Sliding_Sound = 2,

    Player_Attack_Throw_Sound = 3,

    Player_Jump_Sound = 4,

    Player_Double_Jump_Sound = 5,

    Player_Dashing_Sound = 6,

    Player_Hidden_Sound = 7,

    Player_Dead_Sound = 8,

    Player_Rivival_Sound = 9,
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundManager : PlayerAbstract
{
    [Header("PlayerSoundManager")]

    [SerializeField] protected AudioSource _AudioSource;

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

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadAudioSource();
    }

    protected virtual void LoadAudioSource()
    {
        if (this._AudioSource != null) return;

        this._AudioSource = GetComponent<AudioSource>();
    }

    protected virtual void Update()
    {
        if (this._PlayerCtrl.PlayerAnimation.IsDead)//
        {
            this.PlayeSoundWithNameAction("Player_Dead");
            return;
        }

        if (this._PlayerCtrl.PlayerAnimation.Rivive_Again_Ani)
        {
            this.PlayeSoundWithNameAction("Player_Rivival");
            return;
        }

        if (this._PlayerCtrl.PlayerMovement.IsDashing)
        {
            //this.PlayeSoundWithNameAction("Player_Dashing");
            return;
        }

        if (this._PlayerCtrl.PlayerMovement.Rigidbody2D.velocity.y > 0)//
        {
            // this.PlayeSoundWithNameAction("Player_Jump");
            return;
        }

        if (this._AudioSource.isPlaying) return;

        if (this._PlayerCtrl.PlayerAnimation.Wall_Sliding_Ani)
        {
            this.PlayeSoundWithNameAction("Player_Wall_Sliding");
            return;
        }

        if (this._PlayerCtrl.PlayerAnimation.Run_Ani && !this._PlayerCtrl.PlayerAnimation.Dropping)
        {
            this.PlayeSoundWithNameAction("Player_Run");
            return;
        }


        this._AudioSource.clip = null;
        this._AudioSource.Stop();
    }

    public virtual void PlaySoundJump() => this.PlayeSoundWithNameAction("Player_Jump_Sound");
    public virtual void PlaySoundDashing() => this.PlayeSoundWithNameAction("Player_Dashing_Sound");
    protected virtual void PlaySoundHidden() => this.PlayeSoundWithNameAction("Player_Hidden");
    protected virtual void PlaySoundAttackThrow() => this.PlayeSoundWithNameAction("Player_Attack_Throw_Sound");

    protected virtual void PlayeSoundWithNameAction(string nameAction)
    {
        AudioClip clip = GameController.Instance.SystemConfig.SoundManagerSO.SoundPlayerSO.GetAudioClipByNameAction(nameAction);
        this.PlaySound(clip);
    }
    protected virtual void PlaySound(AudioClip clip)
    {
        if (this._AudioSource.isPlaying) return; // Tránh chồng âm

        this._AudioSource.clip = clip;
        this._AudioSource.Play();
    }

}

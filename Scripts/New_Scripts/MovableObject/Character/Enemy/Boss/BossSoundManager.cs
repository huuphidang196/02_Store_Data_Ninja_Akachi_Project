using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSoundManager : CharacterMainSoundManager
{
    [SerializeField] protected BossCtrl _BossCtrl => this._ObjectCtrl as BossCtrl;

    public virtual void PlaySoundJump() => this.PlayeSoundWithNameAction("Sound_Boss_Jump");
    public virtual void PlaySoundShadow() => this.PlayeSoundWithNameAction("Sound_Boss_Shadow");
    public virtual void PlaySoundFlowDark() => this.PlayeSoundWithNameAction("Sound_Boss_FlowDark");
    public virtual void PlaySoundAttackSlash() => this.PlayeSoundWithNameAction("Sound_Boss_FlowDark");

    protected override void PlayeSoundWithNameAction(string nameAction)
    {
        AudioClip clip = GamePlayController.Instance.SystemConfig.SoundCtrlSO.SoundEnemySO.GetAudioClipByNameAction(nameAction);
        this.PlaySound(clip);
    }
}

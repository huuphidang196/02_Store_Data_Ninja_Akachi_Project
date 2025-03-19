using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockHiddenShooterSoundManager : ObjSoundRunOnlyOnce
{
    [SerializeField] protected RockHiddenShooterCtrl _RockHiddenShooterCtrl => this._ObjectCtrl as RockHiddenShooterCtrl;

    [SerializeField] protected TypeProspectSound _TypeProspectSound;

    protected override void Update()
    {
        if (!this._RockHiddenShooterCtrl.RockHiddenShooterOpening.IsActivated) return;

        base.Update();

    }
    protected override AudioClip GetAudioClipToRun()
    {
        return GamePlayController.Instance.SystemConfig.SoundCtrlSO.SoundProspectSO.GetAudioClipByNameTypeProspectSound(this._TypeProspectSound);
    }
}

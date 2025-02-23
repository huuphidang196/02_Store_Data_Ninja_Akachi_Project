using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanceTrapsAutoOnSoundManager : ObjSoundRunOnlyOnce
{
    public LanceTrapEventCtrl LanceTrapEventCtrl => this._ObjectCtrl as LanceTrapEventCtrl;

    [SerializeField] protected TypeProspectSound _TypeProspectSound;


    protected override void Update()
    {
        if (!this.LanceTrapEventCtrl.LanceTrapEventsAutoOn.Activated) return;

        base.Update();

    }
    protected override AudioClip GetAudioClipToRun()
    {
        return GamePlayController.Instance.SystemConfig.SoundCtrlSO.SoundProspectSO.GetAudioClipByNameTypeProspectSound(this._TypeProspectSound);
    }
}

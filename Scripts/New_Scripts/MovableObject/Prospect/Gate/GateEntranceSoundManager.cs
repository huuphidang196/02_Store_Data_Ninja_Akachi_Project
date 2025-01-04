using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateEntranceSoundManager : ObjSoundRunOnlyOnce
{
    [SerializeField] protected TypeProspectSound _TypeProspectSound;

    protected override void Update()
    {
        if (!GateEntranceAutoRun.Instance.WasCom_Mission) return;

        base.Update();

    }
    protected override AudioClip GetAudioClipToRun()
    {
        return GamePlayController.Instance.SystemConfig.SoundCtrlSO.SoundProspectSO.GetAudioClipByNameTypeProspectSound(this._TypeProspectSound);
    }


}

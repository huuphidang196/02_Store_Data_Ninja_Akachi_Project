using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundRespawnTower : ObjSoundRunOnlyOnce
{
    [Header("LightRespawnTower")]
    [SerializeField] protected TypeProspectSound _TypeProspectSound;

    protected override void Update()
    {
        if (PlayerCtrl.Instance.transform.position.x <= this._ObjectCtrl.transform.position.x) return;

        base.Update();

    }
    protected override AudioClip GetAudioClipToRun()
    {
        return GamePlayController.Instance.SystemConfig.SoundCtrlSO.SoundProspectSO.GetAudioClipByNameTypeProspectSound(this._TypeProspectSound);
    }

   
}

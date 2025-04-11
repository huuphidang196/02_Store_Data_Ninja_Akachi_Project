using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundRespawnTower : ObjSoundRunOnlyOnce
{
    [Header("LightRespawnTower")]
    [SerializeField] protected TypeProspectSound _TypeProspectSound;

    public RespawnTowerCtrl RespawnTowerCtrl => this._ObjectCtrl as RespawnTowerCtrl;
    protected override void Update()
    {
        if (!this.RespawnTowerCtrl.LightRespawnTower.WasTurned) return;

        base.Update();

    }
    protected override AudioClip GetAudioClipToRun()
    {
        return GamePlayController.Instance.SystemConfig.SoundCtrlSO.SoundProspectSO.GetAudioClipByNameTypeProspectSound(this._TypeProspectSound);
    }

   
}

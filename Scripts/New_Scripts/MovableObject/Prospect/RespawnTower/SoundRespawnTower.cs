using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundRespawnTower : ObjSoundWasEffectByMusicChanging
{
    [Header("LightRespawnTower")]
    [SerializeField] protected bool wasTurned = false;
    [SerializeField] protected TypeProspectSound _TypeProspectSound;

    protected override void ResetValue()
    {
        base.ResetValue();

        this.wasTurned = false;
    }

    protected virtual void FixedUpdate()
    {
        if (this.wasTurned) return;

        this.wasTurned = PlayerCtrl.Instance.transform.position.x >= this._ObjectCtrl.transform.position.x;

        if (!this.wasTurned) return;

        this.PlaySoundRespawnTower();

    }

    protected virtual void PlaySoundRespawnTower()
    {
        AudioClip audioClip = GameController.Instance.SystemConfig.SoundCtrlSO.SoundProspectSO.GetAudioClipByNameTypeProspectSound(this._TypeProspectSound);

        this.PlaySound(audioClip);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySoundManager : ObjSoundWasEffectByMusicChanging
{
    public EnemyCtrl EnemyCtrl => this._ObjectCtrl as EnemyCtrl;

    [SerializeField] protected TypeActionEnemy _TypeActionEnemy;

    protected virtual void Update()
    {
        this._TypeActionEnemy = this.GetTypeAction();

        if (this._TypeActionEnemy == TypeActionEnemy.NoType)
        {
            this._AudioSource.Stop();
            this._AudioSource.clip = null;
            return;
        }

        if (this._AudioSource.isPlaying && this._AudioSource.clip.name == this.GetNameAction()) return;

        if (this._AudioSource.clip != null && this.GetNameAction() != this.GetNameAction(TypeActionEnemy.Attack)) return;

        this.PlayeSoundWithTypeAction();
    }

    //protected virtual bool CheckStopSoundAttack()
    //{
    //    //Sure that clip diff null
    //    if (this._TypeActionEnemy != TypeActionEnemy.Attack && this._AudioSource.clip.name != this.GetNameAction(TypeActionEnemy.Attack))
    //        return false;

    //    this._AudioSource.Stop();
    //    this._AudioSource.clip = null;

    //    return true;
    //}

    protected virtual TypeActionEnemy GetTypeAction()
    {
        if (this.EnemyCtrl.EnemyDamReceiver.ObjIsDead) return TypeActionEnemy.Dead;

        if (this.EnemyCtrl.EnemyAnimations.Attack) return TypeActionEnemy.Attack;

        if (this.EnemyCtrl.EnemyCheckContactEnviroment.EnemyCheckForward.ForwardObjRight) return TypeActionEnemy.Detect;

        return TypeActionEnemy.NoType;
    }

    protected virtual void PlayeSoundWithTypeAction()
    {
        string nameType = this.GetNameAction();
        //Debug.Log(nameType);
        this.PlayeSoundWithNameAction(nameType);
    }

    protected virtual void PlayeSoundWithNameAction(string nameAction)
    {
        AudioClip clip = GameController.Instance.SystemConfig.SoundCtrlSO.SoundEnemySO.GetAudioClipByNameAction(nameAction);
        this.PlaySound(clip);
    }

    protected virtual string GetNameAction()
    {
        return this.GetNameAction(this._TypeActionEnemy);
    }
    protected virtual string GetNameAction(TypeActionEnemy typeActionEnemy)
    {
        string nameTypeEmemy = this.EnemyCtrl.gameObject.name.Split('_')[1];

        return "Sound_" + nameTypeEmemy + "_" + typeActionEnemy.ToString();
    }
}

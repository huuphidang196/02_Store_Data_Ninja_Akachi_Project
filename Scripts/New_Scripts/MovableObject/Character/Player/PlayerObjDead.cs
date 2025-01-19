using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjDead : PlayerAbstract
{
    [SerializeField] protected int _Count_Life = 3;
    public int Count_Life => this._Count_Life;

    [SerializeField] protected bool _EndGame;
    public bool EndGame => this._EndGame;

    protected override void OnEnable()
    {
        base.OnEnable();

        this._EndGame = false;
    }

    protected override void ResetValue()
    {
        base.ResetValue();

        this._Count_Life = this._PlayerCtrl.PlayerSO.Max_Life;
    }
    public virtual void EventPlayerDead()
    {
        this._Count_Life--;
        if (this._Count_Life <= 0)
        {
            this.EndGamePlay();
            return;
        }
        Invoke(nameof(this.SetPositionOfPlayerRiviveCharacter), 1.9f);
    }

    protected virtual void RiviveCharacter()
    {
        //Set DamReceiver
        this._PlayerCtrl.PlayerDamReceiver.RiviveCharacter();

        //Set animation Rivival
        InputManager.Instance.PlayerRiviveAgain();
    }
    protected virtual void SetPositionOfPlayerRiviveCharacter()
    {
        //Get Pos Respawn Tower
        Vector3 posRivival = RespawnTowerSC.Instance.GetPositionRespawnTowerPlayerDead();
        posRivival.z = CameraFollowTarget.Instance.transform.position.z + 2f;
        // Rivive again

        //Set pos Player
        this._PlayerCtrl.transform.position = posRivival;

        Invoke(nameof(this.RiviveCharacter), 0.1f);
    }

    protected virtual void EndGamePlay()
    {
        //Call to Game Controller
        this._EndGame = true;

    }

    public virtual void RiviveCharacterByMoneyWitTwoLives()
    {
        this._EndGame = false;
        this._Count_Life = 2;
        Invoke(nameof(this.SetPositionOfPlayerRiviveCharacter), 1.9f);
        GamePlayController.Instance.IncreseOrderBuy();
    }    
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjDead : PlayerAbstract
{
    [SerializeField] protected int _Count_Life = 4;
    public int Count_Life => this._Count_Life;

    public virtual void EventPlayerDead()
    {
        this._Count_Life--;
        if (this._Count_Life <= 0)
        {
            this.EndGame();
            return;
        }
        // StartCoroutine(this.CouroutineRiviveCharacter(2f));
        Invoke(nameof(this.RiviveCharacter), 2f);
    }

    protected IEnumerator CouroutineRiviveCharacter(float timeDelay)
    {
        yield return new WaitForSeconds(timeDelay);
        this.RiviveCharacter();
    }
    protected virtual void RiviveCharacter()
    {
        //Get Pos Respawn Tower
        Vector3 posRivival = RespawnTowerSC.Instance.GetPositionRespawnTowerPlayerDead();
        posRivival.z = CameraFollowTarget.Instance.transform.position.z + 2f;
        // Rivive again

        //Set pos Player
        this._PlayerCtrl.transform.position = posRivival;

        //Set DamReceiver
        this._PlayerCtrl.PlayerDamReceiver.RiviveCharacter();

        //Set animation Rivival
        InputManager.Instance.PlayerRiviveAgain();
    }

    protected virtual void EndGame()
    {
        //Call to Game Controller

    }
}

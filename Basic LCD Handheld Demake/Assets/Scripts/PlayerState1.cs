using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState1 : PlayerState
{
    float enteredStateTime;
    int thisState = 1;

    public override void EnterState()
    {
        GameManager.instance.UpdatePlayerSprite(thisState);
        enteredStateTime = Time.time;
    }

    public override void MoveLeft()
    {
        GameManager.instance.ChangePlayerState(GameManager.instance.playerState0);
    }

    public override void PlayerUpdate()
    {
        if (Time.time - enteredStateTime > GameManager.instance.playerHangTime)
            GameManager.instance.ChangePlayerState(GameManager.instance.playerState2);
    }
}

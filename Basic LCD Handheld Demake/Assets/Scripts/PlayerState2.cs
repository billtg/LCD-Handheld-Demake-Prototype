using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState2 : PlayerState
{
    int thisState = 2;

    public override void EnterState()
    {
        GameManager.instance.UpdatePlayerSprite(thisState);
    }
    public override void MoveLeft()
    {
        GameManager.instance.ChangePlayerState(GameManager.instance.playerState3);
    }

    public override void Jump()
    {
        GameManager.instance.ChangePlayerState(GameManager.instance.playerState1);
    }
    public override void PlayerAction()
    {
        //Will drop a held box if there's space, pickup a groundBox if not holding a box, or do nothing if there's no groundBox
        //Check if the player's holding a box
        if (GameManager.instance.playerHoldingBox)
        {
            //Check if there's a space on the ground first. If not, drop
            if (!GameManager.instance.groundBoxes[thisState].activeSelf)
                GameManager.instance.HoldBox(thisState, false);
        }
        //Player isn't holding a box. Check if there's a box and the ground. If so, pick it up.
        else if (GameManager.instance.groundBoxes[thisState].activeSelf)
            GameManager.instance.HoldBox(thisState, true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public PlayerState currentPlayerState;
    public PlayerState0 playerState0 = new PlayerState0();
    public PlayerState1 playerState1 = new PlayerState1();
    public PlayerState2 playerState2 = new PlayerState2();
    public PlayerState3 playerState3 = new PlayerState3();

    public List<GameObject> playerObjects;
    public List<GameObject> heldBoxes;
    public List<GameObject> groundBoxes;

    [HideInInspector]
    public bool playerHoldingBox = false;

    public float playerHangTime;

    private void Awake()
    {
        instance = this;
        currentPlayerState = playerState0;
        UpdatePlayerSprite(0);
        ClearBoxSprites(heldBoxes);
        ClearBoxSprites(groundBoxes);
        //turn on one box
        groundBoxes[3].SetActive(true);
    }

    public void ChangePlayerState(PlayerState state)
    {
        currentPlayerState = state;
        currentPlayerState.EnterState();
    }

    public void UpdatePlayerSprite(int spriteIndex)
    {
        //Clear all playerSprites
        foreach (GameObject playerObject in playerObjects)
            playerObject.SetActive(false);

        //Turn on the sprite sent to this function
        playerObjects[spriteIndex].SetActive(true);

        //Turn on the held box
        if (playerHoldingBox)
        {
            ClearBoxSprites(heldBoxes);
            heldBoxes[spriteIndex].SetActive(true);
        }
    }

    public void ClearBoxSprites(List<GameObject> boxes)
    {
        //Turn all the box objects to inactive (not visible)
        foreach (GameObject boxObject in boxes)
            boxObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            currentPlayerState.MoveLeft();
        if (Input.GetKeyDown(KeyCode.UpArrow))
            currentPlayerState.MoveUp();
        if (Input.GetKeyDown(KeyCode.RightArrow))
            currentPlayerState.MoveRight();
        if (Input.GetKeyDown(KeyCode.DownArrow))
            currentPlayerState.MoveDown();
        if (Input.GetKeyDown(KeyCode.Z))
            currentPlayerState.Jump();
        if (Input.GetKeyDown(KeyCode.X))
            currentPlayerState.PlayerAction();

        currentPlayerState.PlayerUpdate();
    }

    public void HoldBox(int playerState, bool pickup)
    {
        //Pick up or drop a box
        if (pickup)
        {
            playerHoldingBox = true;
            heldBoxes[playerState].SetActive(true);
            groundBoxes[playerState].SetActive(false);
        }
        else
        {
            playerHoldingBox = false;
            heldBoxes[playerState].SetActive(false);
            groundBoxes[playerState].SetActive(true);
        }
    }
}

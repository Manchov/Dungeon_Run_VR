using System;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public bool isOpen = false; // Tracks whether the door is open
    public int openCost = 15; // Cost to open the door
    private float requiredLookTime = 2.0f; // Time in seconds the player needs to look at the door to open it
    private float lookTimer = 0f; // Timer to track how long the player has looked at the door

    // private void Update()
    // {
    //     // If the door is being looked at (checked in GazeInputController), increase the timer
    //     if (GazeInputController.isLookingAtDoor)
    //     {
    //         Debug.Log("Player is looking at the door. dc");
    //         lookTimer += Time.deltaTime;
    //         if (lookTimer >= requiredLookTime)
    //         {
    //             TryToOpenDoor();
    //             lookTimer = 0f; // Reset timer after trying to open the door
    //         }
    //     }
    //     else
    //     {
    //         lookTimer = 0f; // Reset timer if player looks away
    //     }
    // }

    public void TryToOpenDoor()
    {
        // Check if the door is not already open and the player has enough score
        if (!isOpen && UIManager.Instance.score >= openCost)
        {
            UIManager.Instance.AddScore(-openCost); // Deduct the score
            RotateDoorOpen(); // Open the door
            isOpen = true; // Mark the door as open
        }
    }

    private void RotateDoorOpen()
    {
        // Rotate the door to open it by 90 degrees
        transform.Rotate(0, 90, 0, Space.World);
    }

    public void OpenDoor()
    {
        Debug.Log("Player is looking at the door. dc");
        lookTimer += Time.deltaTime;
        if (lookTimer >= requiredLookTime)
        {
            TryToOpenDoor();
            lookTimer = 0f; // Reset timer after trying to open the door
        }
    }
}
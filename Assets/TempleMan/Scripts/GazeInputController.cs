using UnityEngine;

public class GazeInputController : MonoBehaviour
{
    public static bool isLookingAtDoor = false;
    public float interactionDistance = 10f;
    public LayerMask interactableLayer;

    void Update()
    {
        RaycastHit hit;
        Vector3 forward = transform.TransformDirection(Vector3.forward) * interactionDistance;

        // Check if the player's gaze hits an object within the interaction distance and on the interactable layer
        if (Physics.Raycast(transform.position, forward, out hit, interactionDistance, interactableLayer))
        {
            Debug.Log("I see sm");
            DoorController door = hit.collider.GetComponent<DoorController>();
            
            if (door != null)
            {
                // If a DoorController component is found, open THAT specific door
                door.OpenDoor();
            }
            // Check if the object is a door
            // if (hit.collider.GetComponent<DoorController>() != null)
            // {
                // isLookingAtDoor = true;
            // }
            // else
            // {
            //     isLookingAtDoor = false;
            // }
        }
        else
        {
            isLookingAtDoor = false;
        }
    }
}
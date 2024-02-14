using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float interactDistance = 5f; // Max distance to interact with the door

    void Update()
    {
        // Check if the player is pressing the interact button (e.g., mouse click or gaze timer)
        if (Input.GetKeyDown(KeyCode.E)) // Example key, use your actual input method
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, interactDistance))
            {
                
                Debug.Log("I see sm");
                // Check if the object hit is a door
                DoorController door = hit.collider.GetComponent<DoorController>();
                if (door != null)
                {
                    door.TryToOpenDoor();
                }
            }
        }
    }
}
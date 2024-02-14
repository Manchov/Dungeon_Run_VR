using UnityEngine;

public class ExitSpotController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure the player GameObject has the "Player" tag
        {
            // Assuming the UIManager script is attached to a GameObject named "UIManager"
            FindObjectOfType<UIManager>().ShowGameOverMenu();
        }
    }
}
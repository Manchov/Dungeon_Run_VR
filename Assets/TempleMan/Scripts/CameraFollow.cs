using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Target to follow (Player)
    public Vector3 offset = new Vector3(0, 1.96f, 0); // Offset from the player
    public float smoothSpeed = 5f; // How smoothly the camera catches up with the target's movement

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        // transform.position = smoothedPosition;
        transform.position = desiredPosition;

        // Optionally, make the camera look at the player
        // transform.LookAt(target);
    }
}
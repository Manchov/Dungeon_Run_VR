using UnityEngine;

public class VRPlayerMovement : MonoBehaviour
{
    public float speed = 3.0f; // Movement speed
    private CharacterController characterController;
    private Transform vrCameraTransform;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        if (characterController == null)
        {
            Debug.LogError("CharacterController is not attached to the player");
        }

        // Automatically find the VR camera in the scene on start.
        // Assumes the VR camera is tagged as "MainCamera"
        vrCameraTransform = Camera.main.transform;
    }

    void Update()
    {
        // Move the player forward based on where the VR camera is looking
        Vector3 forward = vrCameraTransform.forward;
        Vector3 movementDirection = new Vector3(forward.x, 0, forward.z).normalized; // Ignore vertical component for movement
        characterController.Move(movementDirection * speed * Time.deltaTime);

        // Rotate character model to match the camera's Y rotation only
        Quaternion cameraRotation = Quaternion.Euler(0, vrCameraTransform.eulerAngles.y, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, cameraRotation, Time.deltaTime * 5f);
    }
}
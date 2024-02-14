using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class FootstepSounds : MonoBehaviour
{
    public AudioClip[] footstepSounds; // Drag your footstep sounds here in the Inspector
    public CharacterController characterController;
    public float stepRate = 0.5f; // Time between steps
    private float nextStepTime = 0f;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // if (characterController.isGrounded && characterController.velocity.magnitude > 0.1f && Time.time >= nextStepTime)
        if (characterController.velocity.magnitude > 0.1f && Time.time >= nextStepTime)
        {
            nextStepTime = Time.time + stepRate;
            PlayFootstepSound();
        }
    }

    void PlayFootstepSound()
    {
        int index = Random.Range(0, footstepSounds.Length);
        audioSource.clip = footstepSounds[index];
        audioSource.Play();
    }
}
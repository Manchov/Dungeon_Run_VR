using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{

    private int score = 0;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PirateCoin"))
        {
            score++;
            other.gameObject.GetComponent<CoinSoundOnDestroy>().PlayDestroySound();

            UpdateScoreDisplay(); // Implement this function based on your UI
            // audioSource.PlayOneShot(coinCollectSound,1); // Play the collection sound
        }
    }

    void UpdateScoreDisplay()
    {
        // Update your game's UI with the new score
        UIManager.Instance.AddScore(1);
        Debug.Log("Score: " + score); // Example output
    }
}

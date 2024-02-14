using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject pirateCoinPrefab; // Assign in the inspector
    public float spawnRate = 5f; // How often to spawn a coin
    public Vector3 spawnArea = new Vector3(10f, 0f, 10f); // Size of the spawn area

    private float nextSpawnTime;

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnCoin();
            nextSpawnTime = Time.time + spawnRate;
        }
    }

    void SpawnCoin()
    {
        Vector3 spawnPosition = new Vector3(
            Random.Range(-spawnArea.x / 2, spawnArea.x / 2),
            spawnArea.y, // You can adjust this if you want coins to spawn at different heights
            Random.Range(-spawnArea.z / 2, spawnArea.z / 2)
        ) + transform.position; // Add the spawner's position

        Instantiate(pirateCoinPrefab, spawnPosition, Quaternion.identity);
    }

    // Use Unity's Gizmos to draw the spawn area in the editor
    void OnDrawGizmos()
    {
        Gizmos.color = new Color(0f, 1f, 0f, 0.25f); // Green with transparency
        Gizmos.DrawCube(transform.position + new Vector3(0, spawnArea.y / 2, 0), spawnArea);
    }
}

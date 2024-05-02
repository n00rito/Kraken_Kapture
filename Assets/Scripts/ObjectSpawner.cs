using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject Shark; // Reference to the GameObject prefab to spawn
    public Vector3 spawnAreaCenter; // Center of the spawn area
    public Vector3 spawnAreaSize; // Size of the spawn area

    public float spawnInterval = 5f; // Interval between spawns
    private float nextSpawnTime; // Time when the next spawn will occur
    public int maxSharks = 3; // Maximum number of sharks allowed
    private int sharksSpawned = 0; // Number of sharks spawned
    void Start()
    {
        {
            // Spawn sharks until the maximum limit is reached
            while (sharksSpawned < maxSharks)
            {
                SpawnShark();
            }
            // Initialize next spawn time
            nextSpawnTime = Time.time + spawnInterval;
    }
        void SpawnShark()
        {
            // Generate random position within the spawn area
            Vector3 randomSpawnPosition = GetRandomSpawnPosition();
            // Spawn the shark at the random position
            Instantiate(Shark, randomSpawnPosition, Quaternion.identity);
            // Increment the count of spawned sharks
            sharksSpawned++;
        }
        Vector3 GetRandomSpawnPosition()
        {
            // Generate random coordinates within the spawn area boundaries
            float randomX = Random.Range(spawnAreaCenter.x - spawnAreaSize.x / 2f, spawnAreaCenter.x + spawnAreaSize.x / 2f);
            float randomY = Random.Range(spawnAreaCenter.y - spawnAreaSize.y / 2f, spawnAreaCenter.y + spawnAreaSize.y / 2f);
            float randomZ = Random.Range(spawnAreaCenter.z - spawnAreaSize.z / 2f, spawnAreaCenter.z + spawnAreaSize.z / 2f);

            return new Vector3(randomX, randomY, randomZ);
        }
    }
    void Update()
    {
        // Check if it's time to spawn a new GameObject
        if (Time.time >= nextSpawnTime)
        {
            // Generate a random position within the spawn area
            Vector3 randomSpawnPosition = new Vector3(
                Random.Range(spawnAreaCenter.x - spawnAreaSize.x / 2f, spawnAreaCenter.x + spawnAreaSize.x / 2f),
                Random.Range(spawnAreaCenter.y - spawnAreaSize.y / 2f, spawnAreaCenter.y + spawnAreaSize.y / 2f),
                Random.Range(spawnAreaCenter.z - spawnAreaSize.z / 2f, spawnAreaCenter.z + spawnAreaSize.z / 2f)
            );

            // Spawn the GameObject at the random position
            Instantiate(Shark, randomSpawnPosition, Quaternion.identity);

            // Update next spawn time
            nextSpawnTime = Time.time + spawnInterval;
        }
    }
}
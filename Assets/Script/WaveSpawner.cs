using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] waypoints;
    public float spawnInterval = 2.0f;
    public float initialSpawnDelay = 3.0f; // Add this variable for initial delay....Time that decides when first enemy spawns
    private float spawnTimer = 0.0f;
    private bool hasSpawnedInitialEnemy = false;

    private void Update()
    {
        // Check if it's time to spawn the initial enemy
        if (!hasSpawnedInitialEnemy)
        {
            initialSpawnDelay -= Time.deltaTime;
            if (initialSpawnDelay <= 0)
            {
                SpawnEnemy();
                hasSpawnedInitialEnemy = true;
            }
        }
        else
        {
            // Continue with the regular spawn logic
            spawnTimer += Time.deltaTime;

            if (spawnTimer >= spawnInterval)
            {
                SpawnEnemy();
                spawnTimer = 0.0f;
            }
        }
    }

    void SpawnEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        Enemy enemyMovement = enemy.GetComponent<Enemy>();
        if (enemyMovement != null)
        {
            enemyMovement.waypoints = waypoints;
        }
    }
}

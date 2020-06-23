using System.Collections;
using UnityEngine;

public class SpawnControl : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] tilePrefabs;
    public GameObject obstaclePrefab;
    public GameObject collectablePrefab;
    public GameObject rotationTarget;
    private GameObject[] enemies;
    public Transform spawnPosition;
    private Vector3 relativePos;
    public float spawnDifficultyScale;
    public float defaultSpawnRate;
    public float maxSpawnRate;
    public float spawnMultiplier;
    float spawnRate;
    float nextSpawn = 0f;
    public bool enemiesEnabled = true;

    // Start is called before the first frame update
    void Start()
    {
        spawnRate = defaultSpawnRate;
        relativePos = rotationTarget.transform.position;
        SpawnTiles();
    }


    public void DestroyAllEnemies()
    {
        enemies = GameObject.FindGameObjectsWithTag("Obsticle");

        for (var i = 0; i < enemies.Length; i++)
        {
            Destroy(enemies[i]);
        }
    }

    public void SpawnTiles()
    {
            // Code to execute after the delay
            int randomIndex = Random.Range(0, tilePrefabs.Length);

            Instantiate(tilePrefabs[randomIndex], spawnPosition.position, transform.rotation);   
    }

    void SpawnRandomBlocks()
    {
        if (Time.time > nextSpawn)
        {
            
            SetSpawnRate();
            nextSpawn = Time.time + spawnRate;
            spawnDifficultyScale++;

            // Code to execute after the delay
            int randomIndex = Random.Range(0, spawnPoints.Length);

            for (int i = 0; i < spawnPoints.Length; i++)
            {
                if (randomIndex != i && enemiesEnabled)
                {
                    Instantiate(obstaclePrefab, spawnPoints[i].position, Quaternion.LookRotation(relativePos, Vector3.up));
                }
                else {
                    Instantiate(collectablePrefab, spawnPoints[i].position, Quaternion.LookRotation(relativePos, Vector3.up));
                }
            }
        }
    }

    // Adjusts the spawn rate of obsticles and collectables based on in-game events
    void SetSpawnRate()
    {
        spawnRate = spawnRate - (spawnDifficultyScale * spawnMultiplier);

        if (spawnRate < maxSpawnRate)
        {
            spawnRate = maxSpawnRate;
        }

        if (spawnDifficultyScale == 0)
        {
            spawnRate = defaultSpawnRate;
        }
    }
}

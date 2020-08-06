using System.Collections;
using UnityEngine;

public class SpawnControl : MonoBehaviour
{
    [Header("Overall Variables")]
    private GameObject[] enemies;
    private GameObject[] collectables;
    public GameObject rotationTarget;
    private Vector3 relativePos;

    [Header("Tile Spawner Variables")]
    public GameObject[] easyTiles;
    public GameObject[] mediumTiles;
    public GameObject[] hardTiles;
    public Transform spawnPosition;
    public bool tileSpawnerEnabled;

    [Header("Time Spawner Variables")]
    public Transform[] spawnPoints;
    public GameObject obstaclePrefab;
    public GameObject collectablePrefab;
    public float difficultyMultiplier;
    public float currentSpawnDifficulty;
    public float maxSpawnRate;
    public float defaultSpawnRate;
    public float spawnRate;
    private float nextSpawn;
    public bool enemiesEnabled = true;
    public bool timeSpawnerEnabled;

    // Start is called before the first frame update
    void Start()
    {
        relativePos = rotationTarget.transform.position;
        spawnRate = defaultSpawnRate;

        if (tileSpawnerEnabled) {
            SpawnEasyTiles();
        }
    }

    private void Update()
    {
        if (timeSpawnerEnabled)
        {
            TimeSpawner();
        }
    }

    public void DestroyAllEnemies()
    {
        enemies = GameObject.FindGameObjectsWithTag("Obsticle");

        for (var i = 0; i < enemies.Length; i++)
        {
            Destroy(enemies[i]);
        }
    }

    public void DestroyAllCollectables()
    {
        collectables = GameObject.FindGameObjectsWithTag("Collectable");

        for (var i = 0; i < collectables.Length; i++)
        {
            Destroy(collectables[i]);
        }
    }

    public void SpawnEasyTiles()
    {
        // Code to execute after the delay
        int randomIndex = Random.Range(0, easyTiles.Length);

        Instantiate(easyTiles[randomIndex], spawnPosition.position, transform.rotation);   
    }

    public void SpawnMediumTiles()
    {
        // Code to execute after the delay
        int randomIndex = Random.Range(0, mediumTiles.Length);

        Instantiate(mediumTiles[randomIndex], spawnPosition.position, transform.rotation);
    }

    public void SpawnHardTiles()
    {
        // Code to execute after the delay
        int randomIndex = Random.Range(0, hardTiles.Length);

        Instantiate(hardTiles[randomIndex], spawnPosition.position, transform.rotation);
    }

    public void TimeSpawner()
    {
        if (Time.time > nextSpawn)
        {
            SetSpawnRate();
            nextSpawn = Time.time + spawnRate;
            currentSpawnDifficulty++;
            // Code to execute after the delay
            int randomIndex = Random.Range(0, spawnPoints.Length);
            for (int i = 0; i < spawnPoints.Length; i++)
            {
                if (randomIndex != i && enemiesEnabled)
                {
                    Instantiate(obstaclePrefab, spawnPoints[i].position, Quaternion.LookRotation(relativePos, Vector3.up));
                }
                else
                {
                    Instantiate(collectablePrefab, spawnPoints[i].position, Quaternion.LookRotation(relativePos, Vector3.up));
                }
            }
        }
    }

    // Adjusts the spawn rate of obsticles and collectables based on in-game events
    void SetSpawnRate()
    {
        spawnRate = spawnRate - (currentSpawnDifficulty * difficultyMultiplier);

        if (spawnRate < maxSpawnRate)
        {
            spawnRate = maxSpawnRate;
        }

        if (currentSpawnDifficulty == 0)
        {
            spawnRate = defaultSpawnRate;
        }
    }
}

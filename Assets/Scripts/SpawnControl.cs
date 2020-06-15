using System.Collections;
using UnityEngine;

public class SpawnControl : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject obstaclePrefab;
    public GameObject collectablePrefab;
    public GameObject rotationTarget;
    private GameObject[] enemies;
    private Vector3 relativePos;
    public float spawnDifficultyScale;
    public float defaultSpawnRate;
    public float maxSpawnRate;
    public float spawnMultiplier;
    private float spawnRate;
    float nextSpawn = 0f;

    // Start is called before the first frame update
    void Start()
    {
        spawnRate = defaultSpawnRate;
        relativePos = rotationTarget.transform.position;
    }

    private void FixedUpdate()
    {
        SpawnBlocks();
    }

    // Adjusts the spawn rate of obsticles and collectables based on in-game events
    void SetSpawnRate()
    {
        spawnRate = spawnRate - (spawnDifficultyScale * spawnMultiplier);

        if (spawnRate < maxSpawnRate) {
            spawnRate = maxSpawnRate;
        }

        if (spawnDifficultyScale == 0) {
            spawnRate = defaultSpawnRate;
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

    void SpawnBlocks()
    {
        if (Time.time > nextSpawn)
        {
            SetSpawnRate();
            nextSpawn = Time.time + spawnRate;

            // Code to execute after the delay
            int randomIndex = Random.Range(0, spawnPoints.Length);

            for (int i = 0; i < spawnPoints.Length; i++)
            {
                if (randomIndex != i)
                {
                    Instantiate(obstaclePrefab, spawnPoints[i].position, Quaternion.LookRotation(relativePos, Vector3.up));
                }
                else {
                    Instantiate(collectablePrefab, spawnPoints[i].position, Quaternion.LookRotation(relativePos, Vector3.up));
                }
            }
        }
    }
}

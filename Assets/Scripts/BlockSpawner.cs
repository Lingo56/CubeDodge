using System.Collections;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{

    public Transform[] spawnPoints;
    public GameObject obstaclePrefab;
    public GameObject collectablePrefab;
    public GameObject rotationTarget;
    public GameObject gameManager;
    private Vector3 relativePos;
    private int scoreInterval;
    public float defaultSpawnRate;
    public float maxSpawnRate;
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

    void GameSpeed()
    {
        scoreInterval = gameManager.GetComponent<GameManager>().playerScore;

        switch (scoreInterval)
        {
            case 0:
                spawnRate = defaultSpawnRate;
                break;
            case 50:
                spawnRate = spawnRate - 0.2f;
                break;
            case 100:
                spawnRate = spawnRate - 0.2f;
                break;
        }

        if (spawnRate < maxSpawnRate) {
            spawnRate = maxSpawnRate;
        }
    }

    void SpawnBlocks()
    {
        if (Time.time > nextSpawn)
        {
            GameSpeed();
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

using System.Collections;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{

    public Transform[] spawnPoints;
    public GameObject blockPrefab;
    public float spawnRate = 2f;
    float nextSpawn = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        SpawnBlocks();
    }

    void SpawnBlocks()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;

            // Code to execute after the delay
            int randomIndex = Random.Range(0, spawnPoints.Length);

            for (int i = 0; i < spawnPoints.Length; i++)
            {
                if (randomIndex != i)
                {
                    Instantiate(blockPrefab, spawnPoints[i].position, Quaternion.identity);
                }
            }
        }
    }
}

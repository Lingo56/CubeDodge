using System.Collections;
using UnityEngine;

public class SpawnControl : MonoBehaviour
{
    private GameObject[] enemies;
    public GameObject[] easyTiles;
    public GameObject rotationTarget;
    public Transform spawnPosition;
    private Vector3 relativePos;
    public float defaultSpawnRate;
    float spawnRate;

    // Start is called before the first frame update
    void Start()
    {
        spawnRate = defaultSpawnRate;
        relativePos = rotationTarget.transform.position;
        SpawnEasyTiles();
    }

    public void DestroyAllEnemies()
    {
        enemies = GameObject.FindGameObjectsWithTag("Obsticle");

        for (var i = 0; i < enemies.Length; i++)
        {
            Destroy(enemies[i]);
        }
    }

    public void SpawnEasyTiles()
    {
            // Code to execute after the delay
            int randomIndex = Random.Range(0, easyTiles.Length);

            Instantiate(easyTiles[randomIndex], spawnPosition.position, transform.rotation);   
    }
}

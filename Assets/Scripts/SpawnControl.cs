using System.Collections;
using UnityEngine;

public class SpawnControl : MonoBehaviour
{
    private GameObject[] enemies;
    private GameObject[] collectables;
    public GameObject[] easyTiles;
    public GameObject[] mediumTiles;
    public GameObject[] hardTiles;
    public GameObject rotationTarget;
    public Transform spawnPosition;
    private Vector3 relativePos;

    // Start is called before the first frame update
    void Start()
    {
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
}

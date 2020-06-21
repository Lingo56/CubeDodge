using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public Transform spawnPosition;
    public float tileLength;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnTile(int tileIndex) {
        Instantiate(tilePrefabs[tileIndex], transform.forward * spawnPosition.position.z, transform.rotation);
    }
}

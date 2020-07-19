using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{

    public SpawnControl spawnControl;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "TileTrigger")
        {
            spawnControl.SpawnEasyTiles();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public SpawnControl spawnControl;
    public GameObject completeLevelUI;
    public bool gameCompleted = false;

    public void CompleteLevel()
    {
            spawnControl.GetComponent<SpawnControl>().DestroyAllEnemies();
            spawnControl.GetComponent<SpawnControl>().DestroyAllCollectables();

            SceneManager.LoadScene(2);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public GameObject score;
    public GameObject spawnControl;
    public int playerFullHealth = 3;
    public int playerCurrentHealth;

    // Start is called before the first frame update
    void Start()
    {
        playerCurrentHealth = playerFullHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HealthDown()
    {
        playerCurrentHealth--;

        if (playerCurrentHealth <= 0)
        {
            PlayerDeath();
        }
    }

    public void PlayerDeath()
    {
        score.GetComponent<Score>().playerScore = 0;
        playerCurrentHealth = playerFullHealth;
        spawnControl.GetComponent<SpawnControl>().DestroyAllEnemies();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float restartDelay = 1;
    public Vector3 respawnPoint;
    public GameObject player;
    public GameObject completeLevelUI;
    private GameObject[] enemies;
    public int playerFullHealth = 3;
    private int playerCurrentHealth;
    public int playerScore;

    void Start()
    {
        playerCurrentHealth = playerFullHealth;
        Debug.Log(playerCurrentHealth);
    }

    public void HealthDown() {
        playerCurrentHealth--;
        Debug.Log(playerCurrentHealth);

        if (playerCurrentHealth <= 0) {
            PlayerDeath();
        }
    }

    public void ScoreUp() {
        playerScore++;
    }

    public void PlayerDeath() {
        Debug.Log("Score: " + playerScore);
        playerScore = 0;
        playerCurrentHealth = playerFullHealth;
        DestroyAllEnemies();
    }

    void DestroyAllEnemies()
    {
        enemies = GameObject.FindGameObjectsWithTag("Obsticle");

        for (var i = 0; i < enemies.Length; i++)
        {
            Destroy(enemies[i]);
        }
    }

    public void CompleteLevel()
    {
        completeLevelUI.SetActive(true);
    }
}
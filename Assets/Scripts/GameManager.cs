using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public float restartDelay = 1;
    public Vector3 respawnPoint;
    public GameObject player;
    public GameObject completeLevelUI;
    public int playerHealth;
    public int playerScore;

    public void CompleteLevel() {
        completeLevelUI.SetActive(true);
    }

    public void HealthDown() {
        playerHealth--;

        if (playerHealth <= 0) {
            PlayerDeath();
        }
    }

    public void ScoreUp() {
        playerScore++;
    }

    public void PlayerDeath() {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Invoke("Restart", restartDelay);
            gameHasEnded = false;
        }
    }

    void Restart() {
        Debug.Log("ded");
        player.GetComponent<CharacterController>().transform.position = respawnPoint;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyControl : MonoBehaviour
{
    public int difficultyLevel;
    public PlayerStats playerStats;
    public GameManager gameManager;

    public void SetDifficulty()
    {
        if (playerStats.score < playerStats.mediumDifficultyScore)
        {
            difficultyLevel = 0;
        }
        if (playerStats.score >= playerStats.mediumDifficultyScore && playerStats.score < playerStats.hardDifficultyScore) {
            difficultyLevel = 1;
        }
        if (playerStats.score >= playerStats.hardDifficultyScore && playerStats.score < playerStats.levelCompleteScore) {
            difficultyLevel = 2;
        }
        if (playerStats.score == playerStats.levelCompleteScore)
        {
            gameManager.GetComponent<GameManager>().CompleteLevel();
        }
    }

    public int GetDifficulty()
    {
        return difficultyLevel;
    }
}

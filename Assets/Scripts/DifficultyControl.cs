using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyControl : MonoBehaviour
{
    public int difficultyLevel;
    public PlayerStats playerStats;

    public void SetDifficulty()
    {
        if (playerStats.score >= playerStats.mediumDifficultyScore && playerStats.score < playerStats.hardDifficultyScore) {

        }
        if (playerStats.score >= playerStats.hardDifficultyScore && playerStats.score < playerStats.levelCompleteScore) {

        }

        switch(playerStats.score)
        {
            case 0:
                difficultyLevel = 0;
                break;
            case 45:
                difficultyLevel = 1;
                break;
            case 90:
                difficultyLevel = 2;
                break;
        }
    }

    public int GetDifficulty()
    {
        return difficultyLevel;
    }
}

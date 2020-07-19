using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyControl : MonoBehaviour
{
    public int difficultyLevel;
    public PlayerStats playerStats;

    public void SetDifficulty()
    {
        switch(playerStats.score)
        {
            case 0:
                difficultyLevel = 0;
                break;
            case 75:
                difficultyLevel = 1;
                break;
            case 150:
                difficultyLevel = 2;
                break;
        }
    }

    public int GetDifficulty()
    {
        return difficultyLevel;
    }
}

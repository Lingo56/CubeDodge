using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public TMP_Text scoreDisplay;
    public PlayerStats playerStats;

    // Update is called once per frame
    void Update()
    {
        scoreDisplay.text = playerStats.score.ToString();
    }
}

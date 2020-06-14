using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public GameObject gameManager;
    public Transform player;
    public int playerScore;
    public TMP_Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ScoreUp()
    {
        playerScore++;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = playerScore.ToString();
    }
}

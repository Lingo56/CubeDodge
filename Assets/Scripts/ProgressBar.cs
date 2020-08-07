using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{

    public PlayerStats playerStats;
    public Slider slider;
    public float lerpSpeed;
    float scoreDivision;
    float sliderValue;
    float finalScore;
    float currentScore;

    private void Start()
    {
        finalScore = playerStats.levelCompleteScore;
    }

    void Update()
    {
        SetSliderValue();
    }

    public void SetSliderValue() {
        currentScore = playerStats.score;
        scoreDivision = currentScore / finalScore;
        sliderValue = Mathf.Lerp(sliderValue, scoreDivision, Time.deltaTime * lerpSpeed);
        slider.value = sliderValue;
    }
}

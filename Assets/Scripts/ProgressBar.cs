using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{

    public Transform player;
    public Slider slider;

    void Update()
    {
        slider.value = player.position.z;
    }
}

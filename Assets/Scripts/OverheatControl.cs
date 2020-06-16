using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverheatControl : MonoBehaviour
{
    public GameObject playerControl;
    public Slider overheatMeter;
    public float overheatTime = 15f;
    public float timeLeft;
    public bool overheatEnabled = false;

    // Start is called before the first frame update
    void Start()
    {
        timeLeft = overheatTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (overheatEnabled) {
            Overheat();
        }
    }

    void Overheat()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            overheatMeter.value = timeLeft / overheatTime;
        }
        else
        {
            OverheatDeath();
        }
    }

    void OverheatDeath() {
        timeLeft = overheatTime;
        playerControl.GetComponent<PlayerControl>().HealthDown();
    }
}

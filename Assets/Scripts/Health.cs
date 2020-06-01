using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject gameManager;
    public Transform player;
    public TMP_Text healthText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = gameManager.GetComponent<GameManager>().playerCurrentHealth.ToString();
    }
}

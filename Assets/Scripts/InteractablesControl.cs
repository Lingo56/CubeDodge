using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractablesControl : MonoBehaviour
{
    public InteractablesStats interactablesStats;
    public GameObject interactable;
    private Vector3 moveDirection = Vector3.zero;
    private float forwardForce;
    public int rotationAmount = 0;
    public bool movementEnabled = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (movementEnabled)
        {
            Movement();
        }
    }

    void Movement()
    {
        forwardForce = interactablesStats.interactableSpeed;

        moveDirection = new Vector3(0.0f, 0.0f, forwardForce);

        transform.Translate(moveDirection * Time.deltaTime);

        interactable.transform.Rotate(0, rotationAmount, 0);
    }
}
